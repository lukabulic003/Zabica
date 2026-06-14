using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PausedMenu : MonoBehaviour
{

    public GameObject container;
    public GameObject settingsContainer;
    public GameObject pauseBttn;
    [SerializeField] private Image panel;
    [SerializeField] private Slider _sliderBrightness;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    [SerializeField] private AudioMixer mixer;



    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    //_slider.onValueChanged.AddListener((v) =>
    //    //{
    //    //    Color c = panel.color;
    //    //    c.a = v;
    //    //    panel.color = c;
    //    //});
    //    _sliderBrightness.onValueChanged.AddListener((v) =>
    //    {
    //        _sliderText.text = v.ToString("0.00");

    //        panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, v);
    //        // Implement brightness settings logic here
    //    });
    //}


    void Start()
    {
        // Brightness
        _sliderBrightness.value = PlayerPrefs.GetFloat("Brightness", 1f);

        _sliderBrightness.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0.00");

            panel.color = new Color(
                panel.color.r,
                panel.color.g,
                panel.color.b,
                v
            );

            PlayerPrefs.SetFloat("Brightness", v);
        });

        panel.color = new Color(
            panel.color.r,
            panel.color.g,
            panel.color.b,
            _sliderBrightness.value
        );

        // Audio
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.75f);

        SetMusicVolume(volumeSlider.value);
        SetSfxVolume(sfxSlider.value);

        volumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }


    public void SetMusicVolume(float value)
    {
        if (value <= 0.0001f)
            value = 0.0001f;

        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();
    }

    public void SetSfxVolume(float value)
    {
        if (value <= 0.0001f)
            value = 0.0001f;

        mixer.SetFloat("SfxVolume", Mathf.Log10(value) * 20);

        PlayerPrefs.SetFloat("SfxVolume", value);
        PlayerPrefs.Save();
    }

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

    //    public void onBrightnessChange()
    //    {
    //// Implement brightness settings logic here
    //    }
    public void onSfxChange()
    {
        SetSfxVolume(sfxSlider.value);
    }

    public void onMusicChange()
    {
        SetMusicVolume(volumeSlider.value);
    }



    //private void Load()
    //{
    //    volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    //}
}
