using UnityEngine;

public class HealZone : MonoBehaviour
{
    public int healAmount = 1;

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.UpdateHealth(this.healAmount);
        }

    }
}
