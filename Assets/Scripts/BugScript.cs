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

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null)
                sr.enabled = false;

            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
                col.enabled = false;

            StartCoroutine(LoadNextLevel());
        }
    }

    private IEnumerator LoadNextLevel()
    {

        if (transitionAnimator != null)
        {
            transitionAnimator.SetTrigger("Start");
        }

        yield return new WaitForSeconds(transitionDuration);

        SceneManager.LoadScene(nextSceneName);
    }
}
