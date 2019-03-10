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

    private Cannon cannon;
 

    public void Awake()
    {
        cannon = gameObject.GetComponentsInChildren<Cannon>()[0];
    }

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
            cannon.currentAngle = cannon.currentAngle >= cannon.maxAngle ? cannon.maxAngle : cannon.currentAngle + cannon.cannonSpeed;
            
        if (Input.GetKey("s"))
            cannon.currentAngle = cannon.currentAngle <= cannon.minAngle ? cannon.minAngle : cannon.currentAngle - cannon.cannonSpeed;

        cannon.transform.rotation = Quaternion.Euler(0, 0, cannon.currentAngle);
    }
}
