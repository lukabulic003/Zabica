using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player =
                other.GetComponent<PlayerScript>();

            if (player != null)
            {
                player.isInWater = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player =
                other.GetComponent<PlayerScript>();

            if (player != null)
            {
                player.isInWater = false;
            }
        }
    }
}