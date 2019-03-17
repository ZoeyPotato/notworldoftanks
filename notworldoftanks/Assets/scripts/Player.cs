using UnityEngine;
using System;


public class Player : MonoBehaviour
{
    public Guid PlayerId;
    
    public float MoveSpeed = 4;
    public float MaxMoveRange = 8;
    public float TotalMoved = 0;
    public bool FacingRight = false;

    public float CurHitPoints = 100;
    public float MaxHitPoints = 100;

    private Cannon cannon;

    public AudioClip moveSound1;

    public void Awake()
    {
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

                SoundManager.Instance.PlaySingle(moveSound1);
                gameObject.transform.position += Vector3.left * amountToMove;
            }

            if (Input.GetKey("d"))
            {
                if (!FacingRight)
                    SwapLeftRight();

                SoundManager.Instance.PlaySingle(moveSound1);
                gameObject.transform.position += Vector3.right * amountToMove;
            }
        }
    }

    private void SwapLeftRight()
    {
        FacingRight = !FacingRight;
        gameObject.transform.forward = -gameObject.transform.forward;
    }
}
