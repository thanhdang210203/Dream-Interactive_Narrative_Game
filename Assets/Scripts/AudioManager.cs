using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource m_SFX;
    [SerializeField] private AudioSource m_BackgroundMusic;
    [SerializeField] private AudioSource m_Laser;

    [Header("Sound Effect Clips")]
    public AudioClip[] soundEffects;

    [Header("Background Music Clips")]
    public AudioClip[] backgroundMusic;
    [SerializeField] private float crossfadeTime = 3f; // duration of the crossfade in seconds
    private int currentTrackIndex = -1;
    [SerializeField] private bool shouldStartCrossfade = false;
    [SerializeField] private bool canPlayMusic;

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
    public void PlaySoundEffect(int index)
    {
        // Check if the index is within the bounds of the array
        if (index >= 0 && index < soundEffects.Length)
        {
            if (!m_SFX.isPlaying)
            {
                // Play the sound effect at the given index
                m_SFX.PlayOneShot(soundEffects[index]);
            }
        }
        else
        {
            Debug.Log("Invalid sound effect index: " + index);
        }
    }
    public void PlayBackgroundMusic(int index)
    {
        if (index >= 0 && index < backgroundMusic.Length)
        {
            if(m_BackgroundMusic.isPlaying)
            {
                m_BackgroundMusic.Stop();
                m_BackgroundMusic.PlayOneShot(backgroundMusic[index]);
            }
            else
            {
                m_BackgroundMusic.PlayOneShot(backgroundMusic[index]);
            }
        }
        else
        {
            Debug.Log("Invalid background music index: " + index);
        }
    }
}