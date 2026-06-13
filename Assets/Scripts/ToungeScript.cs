using UnityEngine;

public class TongueScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private float minLength = 0.2f;
    [SerializeField] private float maxLength = 4f;
    [SerializeField] private float growSpeed = 8f;

    [SerializeField] private float mouthOffset = 1f;

    private float currentLength;

    private void Start()
    {
        currentLength = minLength;

        transform.localScale =
            new Vector3(minLength, 2f, 2f);
    }

    private void Update()
    {
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
                2f,
                2f);
    }


    private void UpdateDirection()
    {
        if (playerSprite.flipX)
        {
            transform.localRotation =
                Quaternion.Euler(0f, 180f, 0f);

            transform.localPosition =
                new Vector3(
                    -mouthOffset,
                    1f,
                    1f);
        }
        else
        {
            transform.localRotation =
                Quaternion.identity;

            transform.localPosition =
                new Vector3(
                    mouthOffset,
                    1f,
                    1f);
        }
    }
}