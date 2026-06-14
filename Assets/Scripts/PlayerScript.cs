using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float swimSpeed = 2f;

    private Rigidbody2D rb;
    private float horizontal;
    private bool isGrounded;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite jumpUpSprite;
    [SerializeField] private Sprite jumpTopSprite;
    [SerializeField] private Sprite jumpDownSprite;

    [SerializeField] private Sprite walk1;
    [SerializeField] private Sprite walk2;
    [SerializeField] private Sprite walk3;

    [SerializeField] private float animationSpeed = 0.1f;

    [SerializeField] private float shrinkPercent = 0.05f;

    // Minimalna dozvoljena velicina zabe
    [SerializeField] private float minScale = 0.1f;

    // 0.3 = 30% originalne velicine
    [SerializeField] private float bubblePopThreshold = 0.3f;


    [SerializeField] private AudioClip clickSound;

    private float originalScale;

    private float animationTimer;
    private int currentFrame;

    public bool isInWater = false;

    private float vertical;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale.x;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Okretanje sprite-a
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

        // Animacije rade i na kopnu i u vodi
        if (!isGrounded)
        {
            UpdateJumpSprite();
        }
        else if (Mathf.Abs(horizontal) > 0.1f)
        {
            UpdateWalkAnimation();
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        // Skok samo van vode
        if (!isInWater)
        {
            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }

        // Smanjivanje samo u vodi
        if (isInWater && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newScale =
                transform.localScale * (1f - shrinkPercent);

            if (newScale.x >= minScale)
            {
                transform.localScale = newScale;

                float currentPercent =
                    transform.localScale.x / originalScale * 100f;

                Debug.Log(
                    $"Zaba se smanjila. Trenutna velicina: {currentPercent:F1}%");
            }
            else
            {
                Debug.Log(
                    "Dostignuta minimalna velicina.");
            }
        }
    }

    private void FixedUpdate()
    {
        if (isInWater)
        {
            rb.linearVelocity = new Vector2(
                horizontal * swimSpeed,
                vertical * swimSpeed
            );
        }
        else
        {
            rb.linearVelocity = new Vector2(
                horizontal * moveSpeed,
                rb.linearVelocity.y
            );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Wather"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void UpdateJumpSprite()
    {

        
       AudioManager.Instance.PlaySfx(clickSound);

     
        if (isGrounded)
        {
            spriteRenderer.sprite = idleSprite;
            return;
        }

        float verticalVelocity = rb.linearVelocity.y;

        if (verticalVelocity > 1f)
        {
            spriteRenderer.sprite = jumpUpSprite;
        }
        else if (verticalVelocity < -1f)
        {
            spriteRenderer.sprite = jumpDownSprite;
        }
        else
        {
            spriteRenderer.sprite = jumpTopSprite;
        }
    }

    private void UpdateWalkAnimation()
    {
        if (Mathf.Abs(horizontal) < 0.1f)
        {
            spriteRenderer.sprite = idleSprite;

            animationTimer = 0f;
            currentFrame = 0;

            return;
        }

        animationTimer += Time.deltaTime;

        if (animationTimer >= animationSpeed)
        {
            animationTimer = 0f;

            currentFrame++;

            if (currentFrame > 2)
                currentFrame = 0;

            switch (currentFrame)
            {
                case 0:
                    spriteRenderer.sprite = walk1;
                    break;

                case 1:
                    spriteRenderer.sprite = walk2;
                    break;

                case 2:
                    spriteRenderer.sprite = walk3;
                    break;
            }
        }
    }

    public bool CanPopBubble()
    {
        float currentPercent =
            transform.localScale.x / originalScale;

        Debug.Log(
            $"Velicina zabe: {currentPercent * 100f:F1}%");

        return currentPercent >= bubblePopThreshold;
    }
}