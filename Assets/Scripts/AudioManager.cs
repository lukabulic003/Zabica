using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource sfxSource;
        public AudioClip jumpSound;
        public AudioClip bubblePopSound;



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}