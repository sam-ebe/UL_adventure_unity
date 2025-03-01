using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController2 : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private Transform target;
    private Vector2 moveDirection;
    private float positionDelta;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
            positionDelta = Mathf.Abs(target.position.x - transform.position.x);
            if (positionDelta > 0.1 || Mathf.Abs(target.position.y - transform.position.y) > 0.1)
            {
                Vector2 direction = (target.position - transform.position).normalized;
                //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg * 90f;
                //rb.rotation = angle;
                moveDirection = direction;
            }
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
                Vector2 direction = (target.position - transform.position).normalized * speed;
                rb.linearVelocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
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
