using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;       // Static instance of GameManager which allows it to be accessed by any other script.
    private PlayerManager playerManager;             // Reference to PlayerManager which manages the players....
    

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (Instance == null)

            //if not, set instance to this
            Instance = this;

        //If instance already exists and it's not this:
        else if (Instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        //Get a component reference to the attached BoardManager script
        playerManager = GetComponent<PlayerManager>();

        //Call the InitGame function to initialize the first level 
        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {
        playerManager.SetupPlayers();
    }

    //Update is called every frame.
    void Update()
    {
    }
}
