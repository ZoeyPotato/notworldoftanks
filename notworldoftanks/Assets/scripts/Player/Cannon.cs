using UnityEngine;
using System;


public class Cannon : MonoBehaviour
{
    public float RotateSpeed = 50;
    public float CurAngle = 0;
    public float MaxAngle = 90;
    public float MinAngle = -10;
    public float MaxPower = 1000.0f;
    public float MinPower = 100.0f;
    public float PowerPerSecond = 250.0f;

    public GameObject projectile;
    public GameObject projectileSpawner;

    public AudioClip FireSound;

    private float fireDownCounter = 0.0f;   // counts how long the player has held down the fire button


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
                    amountToRotate = MaxAngle - CurAngle;   // TODO: didn't we need to do abs here or something ewald?

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
            fireDownCounter = Time.time;
            Debug.Log("Fire down start at: " + fireDownCounter);
        }

        if (Input.GetButtonUp("Jump"))
        {
            float buttonDownTime = Time.time - fireDownCounter;
            float firingPower = buttonDownTime * PowerPerSecond;
            
            // Clamp firing power to within min power and max power
            if (firingPower >= MaxPower)
                firingPower = MaxPower;
            if (firingPower < MinPower)
                firingPower = MinPower;

            fireDownCounter = 0.0f;
            Debug.Log("Fire held down for: " + buttonDownTime + " Firing at power: " + firingPower);

            GameObject firedProjectile = Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation) as GameObject;
            firedProjectile.GetComponent<Rigidbody>().AddForce(firedProjectile.transform.up * firingPower, ForceMode.Impulse);

            SoundManager.Instance.PlaySingle(FireSound);
        }
    }
}
