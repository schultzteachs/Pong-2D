using UnityEngine;

// This ensures the GameObject always has an AudioSource attached
[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    // Static instance that other scripts can access from anywhere
    public static SoundController Instance { get; private set; }

    // 1. References to your sound files (assign these in the Inspector)
    [SerializeField] private AudioClip paddleSound;
    [SerializeField] private AudioClip wallSound;
    [SerializeField] private AudioClip winSound;

    // 2. Reference to the AudioSource component
    private AudioSource audioSource;

    private void Awake()
    {
        // Set up the Singleton instance safely
        if (Instance == null)
        {
            Instance = this;
            // Optional: Keeps the sound playing if you change scenes
            // DontDestroyOnLoad(gameObject); 
        }
        else
        {
            // Destroy any accidental duplicate SoundControllers
            Destroy(gameObject);
            return;
        }

        // Automatically find the AudioSource on this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // 3. Call these public methods from your game logic scripts
    public void PlayPaddleSound()
    {
        // PlayOneShot allows sounds to overlap without cutting each other off
        if (paddleSound != null) audioSource.PlayOneShot(paddleSound);
    }

    public void PlayWinSound()
    {
        if (winSound != null) audioSource.PlayOneShot(winSound);
    }

    public void PlayWallSound()
    {
        if (wallSound != null) audioSource.PlayOneShot(wallSound);
    }
}
