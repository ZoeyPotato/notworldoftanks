using UnityEngine;


public class GameManager : MonoBehaviour 
{
    Player currentPlayer;
    bool isRed;


	// Use this for initialization
	void Start () 
    {
        //a lot of work to get the player component of the red ball
        currentPlayer = GameObject.FindGameObjectsWithTag("Red")[0].GetComponent(typeof(Player)) as Player;
        isRed = true;
    }
	
	// Update is called once per frame
	void Update () 
    {
        currentPlayer.PlayerMovement();

        if (currentPlayer.currentMoved >= currentPlayer.maxMoveRange)
        {
            if (!isRed)
                currentPlayer = GameObject.FindGameObjectsWithTag("Red")[0].GetComponent(typeof(Player)) as Player;
            else
                currentPlayer = GameObject.FindGameObjectsWithTag("Blue")[0].GetComponent(typeof(Player)) as Player;
        }
    }
}
