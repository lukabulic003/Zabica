using UnityEngine;

public class ToungeScript : MonoBehaviour
{

    [SerializeField] private Vector3 shortSize = new Vector3(1f, 1f, 1f);
    [SerializeField] private Vector3 longSize = new Vector3(3f, 1f, 1f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.localScale = shortSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.localScale = longSize;
            transform.localPosition = new Vector3(1f, 0f, 0f);
        }
        else
        {
            transform.localScale = shortSize;
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
