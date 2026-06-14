using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float parallaxAmount = 1f;

    [SerializeField] private float leftLimit = -8f;
    [SerializeField] private float rightLimit = 8f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        float t =
            Mathf.InverseLerp(
                leftLimit,
                rightLimit,
                player.position.x);

        float offset =
            Mathf.Lerp(
                -parallaxAmount,
                parallaxAmount,
                t);

        transform.position =
            startPosition -
            Vector3.right * offset;
    }
}