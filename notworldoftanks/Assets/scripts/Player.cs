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
        Movement();

        cannon.UpdateCannon();
    }


    private void Movement()
    {
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            float amountToMove = MoveSpeed * Time.deltaTime;

            // Clamp movement to total allowed movement
            if (TotalMoved + amountToMove >= MaxMoveRange)
                amountToMove = MaxMoveRange - TotalMoved;

            TotalMoved += amountToMove;

            if (Input.GetKey("a"))
            {
                if (FacingRight)
                    SwapLeftRight();

                gameObject.transform.position += Vector3.left * amountToMove;
            }

            if (Input.GetKey("d"))
            {
                if (!FacingRight)
                    SwapLeftRight();

                gameObject.transform.position += Vector3.right * amountToMove;
            }
        }
    }

    private void SwapLeftRight()
    {
        FacingRight = !FacingRight;
        player.transform.forward = -player.transform.forward;
    }
}
