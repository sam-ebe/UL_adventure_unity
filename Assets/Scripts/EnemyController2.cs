using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController2 : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private float positionXDelta;
    private float positionYDelta;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        target = GameObject.Find("PlayerCharacter").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {
            positionXDelta = target.position.x - transform.position.x;
            positionYDelta = target.position.y - transform.position.y;

            Vector2 direction = (target.position - transform.position).normalized;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * 90f;
            //rb.rotation = angle;
            moveDirection = direction;
            
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
                Vector2 direction = (target.position - transform.position).normalized * speed;
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;

            if (Mathf.Abs(positionXDelta) >= Mathf.Abs(positionYDelta))
            {
                Debug.Log(moveDirection.x);
                animator.SetFloat("Move X", moveDirection.x);
                animator.SetFloat("Move Y", 0);
            }
            else
            {
                animator.SetFloat("Move X", 0);
                animator.SetFloat("Move Y", moveDirection.y);
            }
        }       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.UpdateHealth(-1);
        }
    }
}
