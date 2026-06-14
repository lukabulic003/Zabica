using UnityEngine;
using UnityEngine.SceneManagement;

public class Bug2Script : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "Level2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Jezik"))
            return;

        PlayerScript player =
            FindFirstObjectByType<PlayerScript>();

        if (player == null)
        {
            Debug.LogWarning("Player nije pronadjen.");
            return;
        }

        if (player.CanPopBubble())
        {
            Debug.Log("Buba je pojedena!");

            Destroy(gameObject);

            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Zaba je previse mala da pojede bubu.");
        }
    }
}