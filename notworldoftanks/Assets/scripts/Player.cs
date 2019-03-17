﻿using UnityEngine;
using System;
using UnityEngine.UI;

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
    private Slider healthBar;

    public AudioClip MoveSound1;

    public void Awake()
    {
        cannon = gameObject.GetComponentInChildren<Cannon>();
        healthBar = gameObject.GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        healthBar.value = CurHitPoints;
        if (CurHitPoints <= 0)
        {
            //Destroy(gameObject);
        }
    }

    // Is only called by the PlayerManager for the Active Player
    public void UpdateActivePlayer()
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

                SoundManager.Instance.PlaySingle(MoveSound1);
                gameObject.transform.position += Vector3.left * amountToMove;
            }

            if (Input.GetKey("d"))
            {
                if (!FacingRight)
                    SwapLeftRight();

                SoundManager.Instance.PlaySingle(MoveSound1);
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
