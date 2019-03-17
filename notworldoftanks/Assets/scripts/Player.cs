using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public Guid PlayerId;
    
    public float MoveSpeed = 1;
    public float MaxMoveRange = 4;
    public float TotalMoved = 0;
    public bool FacingRight = false;

    public float CurHitPoints = 0;
    public float MaxHitPoints = 100;

    private Player player;
    private Cannon cannon;


    public void Awake()
    {
        player = gameObject.GetComponents<Player>()[0];
        cannon = gameObject.GetComponentsInChildren<Cannon>()[0];
    }

    public void UpdatePlayer()
    {
        movement();

        cannon.UpdateCannon();
    }


    private void movement()
    {
        if ((Input.GetKey("a") || Input.GetKey("d")) && TotalMoved < MaxMoveRange)
        {
            float amountToMove = MoveSpeed * Time.deltaTime;

            if (TotalMoved + amountToMove >= MaxMoveRange)
                amountToMove = MaxMoveRange - TotalMoved;

            TotalMoved += amountToMove;

            if (Input.GetKey("a"))
            {
                if (FacingRight)
                    swapLeftRight();

                gameObject.transform.position += Vector3.left * amountToMove;
            }

            if (Input.GetKey("d"))
            {
                if (!FacingRight)
                    swapLeftRight();

                gameObject.transform.position += Vector3.right * amountToMove;
            }
        }

        // GAMEDESIGN: How will we think about movement when it comes to the balance of the game?
    }

    private void swapLeftRight()
    {
        FacingRight = !FacingRight;
        player.transform.forward = -player.transform.forward;
    }
}
