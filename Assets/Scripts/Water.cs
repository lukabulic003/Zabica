
using UnityEngine;

public class Water : MonoBehaviour
{
    public Vector3 respawnPosition = new Vector3(-8f, -4f, 0f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawnPosition;
        }
    }
}