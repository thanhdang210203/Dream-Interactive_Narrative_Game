using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum AudioSourceType
{
    SFX,
    Background, 
    MinigameMusic
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource m_SFX;
    [SerializeField] private AudioSource m_BackgroundMusic;
    [SerializeField] private AudioSource m_UIMusic;
    

    [Header("Sound Effect Clips")]
    public AudioClip[] soundEffects;
    public AudioClip[] UISoundEffects;

    [Header("Background Music Clips")]
    public AudioClip[] backgroundMusic;
    [SerializeField] private float crossfadeTime = 3f; // duration of the crossfade in seconds
    private int currentTrackIndex = -1;
    [SerializeField] private bool shouldStartCrossfade = false;
    [SerializeField] private bool canPlayMusic;
    private void Awake()
    {
        canPlayMusic = false;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // set vol from save
        m_SFX.volume = PlayerPrefs.GetInt("SFXAudio", 1) == 1 ? 1 : 0;
        m_BackgroundMusic.volume = PlayerPrefs.GetInt("BackgroundMusic", 1) == 1 ? 1 : 0;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
    }

    private void OnDestroy()
    {
        // Unsubscribe the OnSceneLoaded method when the object is destroyed
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // If the loaded scene is the "Loading" scene, stop the music
        if (scene.name == "Loading")
        {
            m_BackgroundMusic.Stop();
        }
        // If the loaded scene is "Menu_2", play the specific song first
        else if (scene.name == "Menu_2")
        {
            // Stop the current music
            m_BackgroundMusic.Stop();

            // Set the current track index to the index of the specific song
            currentTrackIndex = 8/* index of the specific song */;

            // Play the selected track
            m_BackgroundMusic.clip = backgroundMusic[currentTrackIndex];
            m_BackgroundMusic.Play();

            // Log the name of the current background music and the scene it is playing at
            Debug.Log("Now playing: " + m_BackgroundMusic.clip.name + " at scene: " + SceneManager.GetActiveScene().name);
        }
    }
    
    public void PlaySoundEffect(int index)
    {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < soundEffects.Length)
        {
            // Play the sound effect at the given index
            m_SFX.PlayOneShot(soundEffects[index]);
        }
        else
        {
            Debug.Log("Invalid sound effect index: " + index);
        }
    }
    
    public bool CanPlayMusic
    {
        get => canPlayMusic;
        set => canPlayMusic = value;
    }
    
    public void PlayUISoundEffect(int index)
    {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < UISoundEffects.Length)
        {
            // Play the sound effect at the given index
            m_SFX.PlayOneShot(UISoundEffects[index]);
        }
        else
        {
            Debug.Log("Invalid sound effect index: " + index);
        }
    }
    private IEnumerator IncreaseVolumeGradually(float fadeInTime)
    {
        float timer = 0;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float progress = timer / fadeInTime;
            m_BackgroundMusic.volume = Mathf.Lerp(0, 1, progress);
            yield return null;
        }

        m_BackgroundMusic.volume = 1;
    }
    
    public void PlayBackgroundMusic(int index)
    {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < backgroundMusic.Length)
        {
            // Play the sound effect at the given index
            m_SFX.PlayOneShot(backgroundMusic[index]);
        }
        else
        {
            Debug.Log("Invalid sound effect index: " + index);
        }
    }
}