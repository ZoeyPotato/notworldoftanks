using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public Guid playerId;
    public float movementSpeed = 1;
    public float maxMoveRange = 4;
    public float currentMoved = 0;

    public float currentHitPoints = 0;
    public float maxHitPoints = 100;

    public float cannonSpeed = 1;
    public float cannonPower = 50;
    public float currentAngle = 45;
    public float maxAngle = 90;
    public float minAngle = -90;
    

    public void UpdatePlayer()
    {
        PlayerMovement();
        CannonControl();
    }

    public void PlayerMovement()
    {
        if ((Input.GetKey("a") || Input.GetKey("d")) && currentMoved < maxMoveRange)
        {
            // GAMEDESIGN: How will we think about movement when it comes to this and the balance of the game?
            float amountToMove = movementSpeed * Time.deltaTime;

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

    public void CannonControl()
    {
        if (Input.GetKey("w"))
        {
            currentAngle = currentAngle >= maxAngle ? maxAngle : currentAngle + cannonSpeed;
        }
            
        if (Input.GetKey("s"))
        {
            currentAngle = currentAngle <= minAngle ? minAngle : currentAngle - cannonSpeed;
        }
    }
}
