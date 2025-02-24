using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public PlayerControls playerControls;
    private InputAction move;
    private InputAction fire;
    private Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;

    // set up references between scripts
    void Awake()
    {
        playerControls = new PlayerControls();
    }

    //called after all Awake calls are finished
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DamageObsctacle"))
        {
            Debug.Log("I got hurt !");
        }
    }
}
