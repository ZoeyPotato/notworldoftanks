using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;     // Allows other scripts to call functions from SoundManager       
    public AudioSource efxSource;                   // Drag a reference to the audio source which will play the sound effects
    public AudioSource musicSource;                 // Drag a reference to the audio source which will play the music
    public float lowPitchRange = .95f;              // The lowest a sound effect will be randomly pitched
    public float highPitchRange = 1.05f;            // The highest a sound effect will be randomly pitched


    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);   // Set SoundManager to not be destroyed when reloading the scene
    }

    public void PlaySingle(AudioClip clip)
    {
        if(!efxSource.isPlaying)
        {
            efxSource.clip = clip;

            efxSource.Play();
        }
    }

    // choose a random audio clip and a random pitch
    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        efxSource.pitch = randomPitch;
        efxSource.clip = clips[randomIndex];

        efxSource.Play();
    }
}
