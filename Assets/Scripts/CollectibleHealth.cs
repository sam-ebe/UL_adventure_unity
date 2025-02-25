using UnityEngine;

public class CollectibleHealth : MonoBehaviour
{
    public int healthAmount;



    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null && controller.health < controller.maxHealth)
        {
            
            controller.UpdateHealth(this.healthAmount);
            Destroy(gameObject);
        }
    }
}
