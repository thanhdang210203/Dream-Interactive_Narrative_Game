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
    private void Awake()
    {
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