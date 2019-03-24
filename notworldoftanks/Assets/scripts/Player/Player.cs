﻿using UnityEngine;
using UnityEngine.UI;
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
    public bool IsDead = false;

    public AudioClip MoveSound1;

    private Cannon cannon;
    private Slider healthBar;


    public void Awake()
    {
        cannon = gameObject.GetComponentInChildren<Cannon>();
        healthBar = gameObject.GetComponentInChildren<Slider>();
    }

    public void Update()
    {
        HealthUpdate();
    }

    // Is only called by the PlayerManager for the Active Player
    public void UpdateCurrentPlayer()
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
            SoundManager.Instance.PlaySingle(MoveSound1);
        }
    }
    private void SwapLeftRight()
    {
        FacingRight = !FacingRight;
        gameObject.transform.forward = -gameObject.transform.forward;
    }

    private void HealthUpdate()
    {
        healthBar.value = CurHitPoints;
        healthBar.GetComponentInChildren<Text>().text = CurHitPoints + " / " + MaxHitPoints;

        if (CurHitPoints <= 0)
        {
            IsDead = true;
            Destroy(gameObject);
        }
    }
}