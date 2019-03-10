using UnityEngine;
using System.Collections;
using System.Collections.Generic;      
    
public class PlayerManager : MonoBehaviour
{

    public static PlayerManager instance;    //Static instance of PlayerManager which allows it to be accessed by any other script.
    public List<Player> players = new List<Player>();             //All players
    private Player currentPlayer;            //Active player

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
                
            //if not, set instance to this
            instance = this;
            
        //If instance already exists and it's not this:
        else if (instance != this)
                
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);    
            
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
            
        //Call the InitGame function to initialize the players
        InitPlayers();
    }
        
    //Initializes the game for each level.
    void InitPlayers()
    {
        int playerId = 0;
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject gameObject in playerObjects)
        {
            Player player = gameObject.GetComponent(typeof(Player)) as Player;
            player.playerId = playerId;
            players.Add(player);
            playerId++;
        }
        PickFirstPlayer();
    }
        
    void Update()
    {
        //TODO: Check if current player is still current player
        currentPlayer.PlayerMovement();
            
        // Should active be switched now?
        if (currentPlayer.currentMoved >= currentPlayer.maxMoveRange)
        {
            if(currentPlayer.playerId >= players.Count)
            {
                currentPlayer = players[0];
            } else {
                currentPlayer = players[currentPlayer.playerId + 1];
            }
        }
    }
      
    //GameDesign: Who should go first?
    void PickFirstPlayer()
    {
        int randomPlayer = Random.Range(0, players.Count - 1);
        currentPlayer = players[randomPlayer];
    }
}