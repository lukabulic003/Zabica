using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LokvanjScript : MonoBehaviour
{
    [SerializeField] private int flowersNeeded = 2;
    [SerializeField] private float gravityWhenSinking = 2f;

    private Rigidbody2D rb;
    private int flowerCount;
    private bool isSinking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.gravityScale = 0f;

        flowerCount = 0;
        isSinking = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            flowerCount++;

            CheckIfShouldSink();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Flower"))
        {
            flowerCount--;
        }
    }

    private void CheckIfShouldSink()
    {
        if (isSinking)
            return;

        if (flowerCount >= flowersNeeded)
        {
            isSinking = true;
            rb.gravityScale = gravityWhenSinking;
        }
    }
}
