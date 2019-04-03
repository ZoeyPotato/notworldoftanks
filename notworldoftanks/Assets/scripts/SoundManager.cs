using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance = null;     // Allows other scripts to call functions from SoundManager       

    public AudioSource EfxSource;                   // Drag a reference to the audio source which will play the sound effects
    public AudioSource MusicSource;                 // Drag a reference to the audio source which will play the music

    public float LowPitchRange = .95f;              // The lowest a sound effect will be randomly pitched
    public float HighPitchRange = 1.05f;            // The highest a sound effect will be randomly pitched


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
        if(!EfxSource.isPlaying)
        {
            EfxSource.clip = clip;

            EfxSource.Play();
        }
    }

    public void RandomizeSfx(params AudioClip[] clips)   // choose a random audio clip and a random pitch
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        EfxSource.pitch = randomPitch;
        EfxSource.clip = clips[randomIndex];

        EfxSource.Play();
    }
}
