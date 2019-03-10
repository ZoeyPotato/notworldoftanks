using UnityEngine;
using System;
using System.Collections.Generic;
    

public class PlayerManager : MonoBehaviour
{
    private List<Player> players = new List<Player>();             //All players
    private Player currentPlayer;                                  //Active player
    private Queue<Player> playerQueue = new Queue<Player>();       //Keeps a queue of players, whose turn is next


    void Update()
    {
        if (currentPlayer.currentMoved >= currentPlayer.maxMoveRange)
            SwitchCurrentPlayer();

        currentPlayer.UpdatePlayer();
    }

    public void SetupPlayers()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject gameObject in playerObjects)
        {
            Player player = gameObject.GetComponent(typeof(Player)) as Player;
            player.playerId = Guid.NewGuid();
            players.Add(player);
            playerQueue.Enqueue(player);
        }

        currentPlayer = playerQueue.Dequeue();
        playerQueue.Enqueue(currentPlayer);
    }
      
    // GAMEDESIGN: Who should go first? And where do they end up on the queue? Track Delay?
    public void SwitchCurrentPlayer()
    {
        currentPlayer.currentMoved = 0;
        currentPlayer = playerQueue.Dequeue();
        playerQueue.Enqueue(currentPlayer);
    }
}
