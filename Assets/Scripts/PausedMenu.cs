using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PausedMenu : MonoBehaviour
{

    public GameObject container;
    public GameObject settingsContainer;
    public GameObject pauseBttn;
    //[SerializeField] private Image panel;
    //[SerializeField] private Slider _slider;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    _slider.onValueChanged.AddListener((v) =>
    //    {
    //        Color c = panel.color;
    //        c.a = v;
    //        panel.color = c;
    //    });
    //}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            pauseBttn.SetActive(false);
            Time.timeScale = 0;

        }

    }

    public void onPauseClick()
    {
        container.SetActive(true);
        pauseBttn.SetActive(false);
        Time.timeScale = 0;
    }

    public void onResumeClick()
    {
        container.SetActive(false);
        pauseBttn.SetActive(true);
        Time.timeScale = 1;
    }


    public void onEndClick()
    {

#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    



}

    public void onRestartClick()
    {
        Time.timeScale = 1;
        var currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
    }


    public void onSettingsClick()
    {
        settingsContainer.SetActive(true);
        container.SetActive(false);
    }

    public void onBackClick()
    {
        settingsContainer.SetActive(false);
        container.SetActive(true);
    }

    public void onBrightnessChange()
    {
// Implement brightness settings logic here
    }

}
