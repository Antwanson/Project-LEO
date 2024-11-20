using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip IntroFightingMusic;   // The intro music clip
    public AudioClip NormalFightingMusic; // The looping music clip

    void Start()
    {
        // Set the intro music and play it
        audioSource.clip = IntroFightingMusic;
        audioSource.loop = false; // Ensure the intro music does not loop
        audioSource.Play();
    }

    void Update()
    {
        // Check if the intro music has finished playing
        if (!audioSource.isPlaying && audioSource.clip == IntroFightingMusic)
        {
            PlayLoopingMusic();
        }
    }

    void PlayLoopingMusic()
    {
        // Switch to the looping music
        audioSource.clip = NormalFightingMusic;
        audioSource.loop = true; // Enable looping for the new track
        audioSource.Play();
    }
}
