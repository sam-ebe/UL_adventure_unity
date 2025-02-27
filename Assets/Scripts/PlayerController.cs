using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 100;
    public PlayerControls playerControls;
    // Variables related to temporary invincibility
    public float timeInvincible = 2.0f;
    private bool isInvincible;
    private float damageCooldown;

    public float intervalHeal = 0.5f;
    private bool isInHealInterval;
    private float healCooldown;

    private int currentHealth;
    private InputAction move;
    private InputAction fire;
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;

    public int health {
        get { 
            return currentHealth; 
        } 
    }
    // set up references between scripts
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    //called after all Awake calls are finished
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.Player.Move.ReadValue<Vector2>();

        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
        if (isInHealInterval)
        {
            healCooldown -= Time.deltaTime;
            if (healCooldown < 0)
            {
                isInHealInterval = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;
        rb.MovePosition(position);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
    }

    public void UpdateHealth (int amount)
    {
        if( amount < 0 )
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        } else
        {
            if (isInHealInterval)
            {
                return;
            }
            isInHealInterval = true;
            healCooldown = intervalHeal;
        }

        this.currentHealth = Mathf.Clamp(currentHealth + amount, 0, this.maxHealth);
        UIHandler2.instance.SetHealthValue(this.currentHealth / (float)maxHealth);
    }
}
