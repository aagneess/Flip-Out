using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource; // Corrected spelling and accessibility

    [Header("Audio Clips")]
    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
    public AudioClip gameOverMusic;

    public static AudioManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this AudioManager across scenes
            musicSource = GetComponent<AudioSource>();  // Get the AudioSource component
        }
        else
        {
            Destroy(gameObject);  // Ensure there's only one instance of AudioManager
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    private void PlayMusicForScene(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName)
        {
            case "Main Menu":
            case "Win Screen":
                clipToPlay = mainMenuMusic;
                break;
            case "Playtest":
                clipToPlay = gameplayMusic;
                break;
            case "Game Over":
            case "Credits":
                clipToPlay = gameOverMusic;
                break;
        }

        // Play the selected clip if it's different from the current one
        if (clipToPlay != null && musicSource.clip != clipToPlay)
        {
            musicSource.clip = clipToPlay;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
