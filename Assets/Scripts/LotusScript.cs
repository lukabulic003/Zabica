using UnityEngine;

public class LotusScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<TongueScript>() != null)
        {
            Destroy(gameObject);
        }
    }
}