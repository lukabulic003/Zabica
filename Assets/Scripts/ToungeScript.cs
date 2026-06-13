using UnityEngine;

public class TongueScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private float minLength = 0.2f;
    [SerializeField] private float maxLength = 4f;
    [SerializeField] private float growSpeed = 8f;

    private float currentLength;

    private SpriteRenderer tongueRenderer;

    private void Start()
    {
        tongueRenderer = GetComponent<SpriteRenderer>();
        currentLength = minLength;

        transform.localScale =
            new Vector3(minLength, 1f, 1f);
    }

    private void Update()
    {
        float horizontal =
        Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(horizontal) > 0.1f &&
            !Input.GetKey(KeyCode.Space))
        {
            tongueRenderer.enabled = false;
        }
        else
        {
            tongueRenderer.enabled = true;
        }

        UpdateDirection();

        if (Input.GetKey(KeyCode.Space))
        {
            currentLength +=
                growSpeed * Time.deltaTime;
        }
        else
        {
            currentLength -=
                growSpeed * Time.deltaTime;
        }

        currentLength =
            Mathf.Clamp(
                currentLength,
                minLength,
                maxLength);

        transform.localScale =
            new Vector3(
                currentLength,
                1f,
                1f);
    }

    private void UpdateDirection()
    {
        if (playerSprite.flipX)
        {
            transform.localRotation =
                Quaternion.Euler(0f, 180f, 0f);

            transform.localPosition =
                new Vector3(-1f, 1f, 0f);
        }
        else
        {
            transform.localRotation =
                Quaternion.identity;

            transform.localPosition =
                new Vector3(1f, 1f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("TongueTarget"))
            return;

        Debug.Log("Pogodio sam metu");
    }
}