using UnityEngine;
using System.Collections.Generic;


public class PlayerManager : MonoBehaviour
{
    private List<Player> players = new List<Player>();             //All players
    private Player curPlayer;                                      //Current active player
    private Queue<Player> playerQueue = new Queue<Player>();       //Keeps a queue of players, whose turn is next


    void Update()
    {
        if (curPlayer.IsDead)
            SwitchCurPlayer();

        if (curPlayer.TotalMoved >= curPlayer.MaxMoveRange)
            SwitchCurPlayer();

        curPlayer.UpdateCurrentPlayer();

        if (playerQueue.Count == 1) //TODO: Make work
            Application.Quit();
    }

    public void SetupPlayers()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject gameObject in playerObjects)
        {
            Player player = gameObject.GetComponent(typeof(Player)) as Player;
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

        if (!curPlayer.IsDead)
            playerQueue.Enqueue(curPlayer);
        else
            SwitchCurPlayer();
    }
}
