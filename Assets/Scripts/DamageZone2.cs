using UnityEngine;

public class DamageZone2 : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null)
        {
            controller.UpdateHealth(-this.damageAmount);
        }

    }

}
