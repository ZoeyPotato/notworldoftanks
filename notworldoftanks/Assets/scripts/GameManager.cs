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

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        playerManager = GetComponent<PlayerManager>();
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        playerManager.SetupPlayers();
    }
}
