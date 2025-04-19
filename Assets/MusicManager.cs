using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip IntroFightingMusic;   // The intro music clip
    public AudioClip NormalFightingMusic; // The looping music clip

    //needs to be a singleton
    private static MusicManager instance;

    public void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            instance = this; // Set the instance to this object
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy this object if another instance already exists
        }   
    }


    void Start()
    {
        // Set the intro music and play it
        audioSource.clip = IntroFightingMusic;
        audioSource.loop = false; // Ensure the intro music does not loop
        audioSource.Play();
        //set volume to 0.5f
        audioSource.volume = 0.5f; // Set the volume to 50%
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

    public void StopMusic()
    {
        // Stop the music
        audioSource.Stop();
    }

    // This function is called when the player enters the combat state
    public void SwitchCombat(){
        StopMusic();
        //TODO: play combat music
    }
    // This function is called when player enters the intense combat state
    public void SwitchIntenseCombat(){
        StopMusic();
        //TODO: play intense combat music
    }
    // This function is called when player enters menu/Character select/Map select/ pause?
    public void SwitchMenu(){
        StopMusic();
        //TODO: play menu music
    }
}
