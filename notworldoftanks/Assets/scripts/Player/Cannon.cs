using UnityEngine;
using System;

public class Cannon : MonoBehaviour
{
    public float RotateSpeed = 50;
    public float CurAngle = 0;
    public float MaxAngle = 90;
    public float MinAngle = -10;
    public float MaximumPower = 1000.0f;
    public float TimeFirePressed = 0.0f;
    public float PowerPerSecond = 250.0f;

    public GameObject projectile;
    public GameObject projectileSpawner;

    public AudioClip fireSound1;


    public void UpdateCannon()
    {
        Rotation();
        Fire();
    }


    private void Rotation()
    {
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            float amountToRotate = RotateSpeed * Time.deltaTime;

            if (Input.GetKey("w"))
            {
                if (CurAngle + amountToRotate >= MaxAngle)
                    amountToRotate = MaxAngle - CurAngle;

                CurAngle += amountToRotate;
                gameObject.transform.Rotate(0, 0, amountToRotate);
            }

            if (Input.GetKey("s"))
            {
                if (CurAngle - amountToRotate <= MinAngle)
                    amountToRotate = Math.Abs(MinAngle) - Math.Abs(CurAngle);

                CurAngle -= amountToRotate;
                gameObject.transform.Rotate(0, 0, -amountToRotate);
            }
        }
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Jump"))
        {
            TimeFirePressed = Time.time;
            Debug.Log("Start Time: " + TimeFirePressed);
        }

        if(Input.GetButtonUp("Jump"))
        {
            float timePressed = Time.time - TimeFirePressed;
            float pressedPower = timePressed * PowerPerSecond;
            Debug.Log("Time Pressed in Seconds: " + timePressed + " Power: " + pressedPower);

            GameObject firedProjectile = Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation) as GameObject;
            firedProjectile.GetComponent<Rigidbody>().AddForce(firedProjectile.transform.up * pressedPower, ForceMode.Impulse);
            SoundManager.Instance.PlaySingle(fireSound1);
            TimeFirePressed = 0.0f;
        }
    }
}
