using UnityEngine;

public class Bug : MonoBehaviour
{

    public GameObject bug;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void onTriggerEnter(Collider other)
    {
        bug.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
