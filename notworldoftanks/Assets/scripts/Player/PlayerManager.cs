using UnityEngine;
using System;
using System.Collections.Generic;
    

public class PlayerManager : MonoBehaviour
{
    private List<Player> players = new List<Player>();             //All players
    private Player curPlayer;                                      //Current active player
    private Queue<Player> playerQueue = new Queue<Player>();       //Keeps a queue of players, whose turn is next


    void Update()
    {
        if (curPlayer.TotalMoved >= curPlayer.MaxMoveRange)
            SwitchCurPlayer();

        curPlayer.UpdateActivePlayer();
    }

    public void SetupPlayers()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject gameObject in playerObjects)
        {
            Player player = gameObject.GetComponent(typeof(Player)) as Player;
            player.PlayerId = Guid.NewGuid();
            players.Add(player);
            playerQueue.Enqueue(player);
        }

        curPlayer = playerQueue.Dequeue();
        playerQueue.Enqueue(curPlayer);
    }


    private void SwitchCurPlayer()
    {
        curPlayer.TotalMoved = 0;
        curPlayer = playerQueue.Dequeue();
        playerQueue.Enqueue(curPlayer);
    }
}
