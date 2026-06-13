using UnityEngine;

public class ToungeScript : MonoBehaviour
{
    [SerializeField] private float maxLength = 3f;
    [SerializeField] private float extendSpeed = 8f;
    [SerializeField] private float pullSpeed = 5f;
    [SerializeField] private float stopDistance = 0.5f;

    private Vector3 startPosition;
    private Vector3 startScale;

    private float currentLength;

    private Rigidbody2D grabbedRb;

    private void Start()
    {
        startPosition = transform.localPosition;
        startScale = transform.localScale;

        currentLength = 1f;
    }

    private void Update()
    {
        bool tongueExtended = Input.GetKey(KeyCode.Space);

        float targetLength = tongueExtended
            ? maxLength
            : 1f;

        currentLength = Mathf.MoveTowards(
            currentLength,
            targetLength,
            extendSpeed * Time.deltaTime
        );

        transform.localScale = new Vector3(
            startScale.x * currentLength,
            startScale.y,
            startScale.z
        );

        transform.localPosition = new Vector3(
            startPosition.x +
            (startScale.x * (currentLength - 1f)) / 2f,
            startPosition.y,
            startPosition.z
        );

        if (!tongueExtended && grabbedRb != null)
        {
            grabbedRb.linearVelocity = Vector2.zero;
            grabbedRb = null;
        }
    }

    private void FixedUpdate()
    {
        if (grabbedRb == null)
            return;

        float distance = Vector2.Distance(
            grabbedRb.position,
            transform.parent.position
        );

        if (distance > stopDistance)
        {
            Vector2 direction =
                ((Vector2)transform.parent.position -
                grabbedRb.position).normalized;

            grabbedRb.linearVelocity =
                direction * pullSpeed;
        }
        else
        {
            grabbedRb.linearVelocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pullable"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                grabbedRb = rb;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pullable"))
        {
            if (grabbedRb == other.GetComponent<Rigidbody2D>())
            {
                grabbedRb.linearVelocity = Vector2.zero;
                grabbedRb = null;
            }
        }
    }
}