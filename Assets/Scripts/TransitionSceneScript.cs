using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionAnimation : MonoBehaviour
{
    [SerializeField] private float animationDuration = 3f;
    [SerializeField] private string nextScene;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(animationDuration);

        SceneManager.LoadScene(nextScene);
    }
}