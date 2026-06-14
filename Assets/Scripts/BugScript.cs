using UnityEngine;
public class BugScript : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Jezik"))
        {
            Debug.Log("GOTOV LEVEL");
        }
    }
}