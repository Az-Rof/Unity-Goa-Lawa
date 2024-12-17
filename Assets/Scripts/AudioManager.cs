using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Audio[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    string currentSceneName;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
        currentSceneName = SceneManager.GetActiveScene().name;
        PlayMusicForScene(currentSceneName);
    }

    public void Start()
    {

        if (PlayerPrefs.HasKey("musicVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("musicVolume");
        }
        if (PlayerPrefs.HasKey("sfxVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("sfxVolume");
        }
    }
    void Update()
    {
        
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = scene.name;
        PlayMusicForScene(currentSceneName);
    }



    /// Plays the music with the specified name.
    private void PlayMusicForScene(string sceneName)
    {
        if (sceneName != null)
        {
            switch (sceneName)
            {

                case "MainMenu":
                    PlayMusic("MainMenu");
                    break;

                case "Level1":
                    PlayMusic("Level1");
                    break;
                default:
                    // Add default logic
                    break;
            }
        }
    }

    public void PlayMusic(string name)
    {
        Audio sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.LogError($"Music sound not found: {name}");
            return;
        }

        if (musicSource.clip == sound.audioClip && musicSource.isPlaying)
        {
            Debug.Log($"Music {name} is already playing.");
            return;
        }

        musicSource.clip = sound.audioClip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Audio sound = Array.Find(sfxSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.LogError($"SFX sound not found: {name}");
            return;
        }

        sfxSource.PlayOneShot(sound.audioClip);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("musicVolume", volume);
        
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
}