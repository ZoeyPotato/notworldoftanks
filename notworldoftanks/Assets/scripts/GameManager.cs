using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;       // Static instance of GameManager which allows it to be accessed by any other script.
    private PlayerManager playerManager;             // Reference to PlayerManager which manages the players....
    

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);   // Set the gamemanager to not be destroyed when reloading scenes

        playerManager = GetComponent<PlayerManager>();
        InitGame();
    }

    void InitGame()
    {
        playerManager.SetupPlayers();
    }
}
