using UnityEngine;
using System.Collections.Generic;
public class Water : MonoBehaviour
{
    public Transform SpawnPoint;
    private HashSet<Collider2D> lotusiNaPlatformi = new HashSet<Collider2D>();
    private bool prosoLokvanj = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !prosoLokvanj)
        {
            other.transform.position = SpawnPoint.position;
        }

        if (other.CompareTag("Lotus"))
        {
            prosoLokvanj = true;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
}