using UnityEngine;
using System.Collections.Generic;
public class LokvanjScript : MonoBehaviour
{
    private HashSet<Collider2D> lotusiNaPlatformi = new HashSet<Collider2D>();
    public int potrebanBrojZaPad = 2;
    public float brzinaPada = 2f;
    private bool pada = false;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(gameObject.name + " - ENTER kolizija sa: " + other.gameObject.name + " (tag: " + other.gameObject.tag + ")");
        if (other.gameObject.CompareTag("Lotus"))
        {
            lotusiNaPlatformi.Add(other.collider);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(gameObject.name + " - EXIT kolizija sa: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Lotus"))
        {
            lotusiNaPlatformi.Remove(other.collider);
        }
    }
    void Update()
    {
        if (lotusiNaPlatformi.Count >= potrebanBrojZaPad)
        {
            pada = true;
        }
        if (pada)
        {
            transform.position += Vector3.down * brzinaPada * Time.deltaTime;
        }
    }
}