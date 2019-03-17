using UnityEngine;


public class Loader : MonoBehaviour
{
    public GameManager GameManager;
    public SoundManager SoundManager;

    void Awake()
    {
        if (GameManager.Instance == null)
            Instantiate(GameManager);
        if (SoundManager.Instance == null)
            Instantiate(SoundManager);
    }
}
