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
            switchCurPlayer();

        curPlayer.UpdatePlayer();

        // TODO: clamp all players to z axis so we don't fall off the front/back
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

        // GAMEDESIGN: Who should go first? And where do they end up on the queue? Track Delay?
    }


    private void switchCurPlayer()
    {
        curPlayer.TotalMoved = 0;
        curPlayer = playerQueue.Dequeue();
        playerQueue.Enqueue(curPlayer);
    }
}
