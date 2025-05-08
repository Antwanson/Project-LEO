using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip IntroFightingMusic;   // The intro music clip
    public AudioClip NormalFightingMusic; // The looping music clip
    public AudioClip IntenseCombatMusic; // The intense combat music clip
    public AudioClip MenuMusic; // The menu music clip

    public bool menuFlag = true; // Flag to determine if we are in a menu scene

    // Singleton instance
    private static MusicManager instance;

    public float menuVolume = 1f; // Volume for menu music
    public float combatVolume = 0.5f; // Volume for combat music
    public float intenseCombatVolume = 1f; // Volume for intense combat music

    private float startingVolume = 1f;

    private void Awake()
    {
        startingVolume = audioSource.volume; // Store the initial volume
        // Ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene loads
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene load events
            // set volume of intro fighting music to 0.5f
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        // Set initial music based on the current scene
        SetInitialMusic();
    }

    void SetInitialMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // If we are in PlayerTestingMap, play the intro music
        if (currentScene == "Map1" || currentScene == "PlayerTestingMap" || currentScene == "Map2")
        {
             // Set the volume (adjust as needed)
            audioSource.volume = startingVolume * combatVolume; // Set the volume for combat music
            PlayMusic(IntroFightingMusic, false);
            // audioSource.volume = 0.18f;
        }
        // Otherwise, keep playing MenuMusic for any non-gameplay scene
        else
        {
            // audioSource.volume = 1f; // Set the volume (adjust as needed)
            audioSource.volume = startingVolume * menuVolume; // Set the volume for menu music
            PlayMusic(MenuMusic, true);
        }
    }

    void Update()
    {
        // If intro music finishes, start normal fighting music
        if (!audioSource.isPlaying && audioSource.clip == IntroFightingMusic)
        {
            // Set the volume for combat music
            audioSource.volume = startingVolume * combatVolume; // Set the volume for combat music
            PlayMusic(NormalFightingMusic, true);
        }
    }

    private void PlayMusic(AudioClip clip, bool loop)
    {
        // Play the specified music clip
        audioSource.clip = clip;
        audioSource.loop = loop;
        //audioSource.volume = 0.5f; // Set the volume (adjust as needed)
        audioSource.Play();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Automatically set music based on the scene loaded
        string sceneName = scene.name;
        Debug.Log("Scene loaded: " + sceneName);

        // Menu music should be active in all non-gameplay scenes
        if (sceneName == "Map1" || sceneName == "PlayerTestingMap" || sceneName == "Map2")
        {
            audioSource.volume = startingVolume * combatVolume; // Set the volume for combat music
            PlayMusic(IntroFightingMusic, false); // Play intro music for the testing map
            // audioSource.volume = 0.18f; // Set the volume (adjust as needed)
            menuFlag = false; // Set menuFlag to false for gameplay scenes
        }
        else
        {
            if (menuFlag  == false)
            {
                audioSource.volume = startingVolume * menuVolume;
               PlayMusic(MenuMusic, true); // Play menu music for all other scenes
            //    audioSource.volume = 1f; // Set the volume (adjust as needed)
            }
           menuFlag = true; // Set menuFlag to true for non-gameplay scenes
        }
    }

    // Call these functions to switch to combat music states when needed
    public void SwitchCombat()
    {
        
        if (audioSource.clip != NormalFightingMusic)
        {
            //set volume to 0.5f
            audioSource.volume = startingVolume * combatVolume;
            PlayMusic(NormalFightingMusic, true);
        }
    }

    public void SwitchIntenseCombat()
    {
        if (audioSource.clip != IntenseCombatMusic)
        {
            //set volume to 1f
            audioSource.volume = startingVolume * intenseCombatVolume;
            PlayMusic(IntenseCombatMusic, true);
        }
    }

    public void SwitchMenu()
    {
        // Ensure menu music is playing when we switch to a menu
        audioSource.volume = startingVolume * menuVolume;
        PlayMusic(MenuMusic, true);
    }
}
