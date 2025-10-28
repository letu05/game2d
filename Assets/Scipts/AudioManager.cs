using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioManager instance;
    public AudioManager Intance
    {
        get => instance;
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [Header("Audio Sources")]
    public AudioSource musicSource;
    [Header("Audio Clips")] 
    public AudioClip backgroundMusic;

    public void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }
    private void Start()
    {
        PlayBackgroundMusic();
    }
}
