using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Jezik"))
            return;

        PlayerScript player =
            FindFirstObjectByType<PlayerScript>();

        if (player == null)
        {
            Debug.LogWarning("Player nije pronadjen.");
            return;
        }

        if (player.CanPopBubble())
        {
            Debug.Log("Bubble pukao!");

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Zaba je previse mala da pukne bubble.");
        }
    }
}
