using UnityEngine;

public class MovableBrick : MonoBehaviour
{
    public float pushDistance = 1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        Vector2 direction =
            (transform.position - collision.transform.position).normalized;

        direction.x = Mathf.Round(direction.x);
        direction.y = Mathf.Round(direction.y);

        transform.position += (Vector3)(direction * pushDistance);
    }
}