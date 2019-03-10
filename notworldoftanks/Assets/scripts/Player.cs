using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public Guid playerId;
    public float speed = 1;
    public float maxMoveRange = 4;
    public float currentMoved = 0;


    public void PlayerMovement()
    {
        if (currentMoved < maxMoveRange)
        {
            // GameDesign: How will we think about movement when it comes to this and the balance of the game?
            float amountToMove = speed * Time.deltaTime;

            if (currentMoved + amountToMove >= maxMoveRange)
            {
                amountToMove = maxMoveRange - currentMoved;
                currentMoved = maxMoveRange;
            }

            if (Input.GetKey("a"))
                gameObject.transform.position += Vector3.left * amountToMove;
            if (Input.GetKey("d"))
                gameObject.transform.position += Vector3.right * amountToMove;

            currentMoved += amountToMove;
        }
    }
}
