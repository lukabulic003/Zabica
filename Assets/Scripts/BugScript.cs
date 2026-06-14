using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BugScript : MonoBehaviour
{
    [SerializeField] private Animator transitionAnimator;
    [SerializeField] private string nextSceneName;
    [SerializeField] private float transitionDuration = 1f;

    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished) return;

        if (other.CompareTag("Jezik"))
        {
            finished = true;
            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {
        transitionAnimator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}