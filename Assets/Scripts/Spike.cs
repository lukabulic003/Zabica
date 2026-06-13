using UnityEngine;

public class Spike : MonoBehaviour
{
    public Transform SpawnPoint;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = SpawnPoint.position;
        }
    }
}