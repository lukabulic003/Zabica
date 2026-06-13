using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    public void onStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onEndClick()
    {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

}
