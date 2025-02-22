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


    void Awake()
    {
        playerControls = new PlayerControls();
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
        transform.position = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
       // rb.linearVelocity = new Vector2(moveDirection.x * speed * Time.deltaTime, moveDirection.y * speed * Time.deltaTime);
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Fired");
    }
}
