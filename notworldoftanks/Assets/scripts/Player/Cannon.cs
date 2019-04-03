using UnityEngine;
using System;


public class Cannon : MonoBehaviour
{
    public float RotateSpeed = 50;
    public float CurAngle = 0;
    public float MaxAngle = 90;
    public float MinAngle = -10;

    public float MaxFirePower = 1000.0f;
    public float MinFirePower = 100.0f;
    public float FirePowerChargeRate = 250.0f;

    public GameObject Projectile;
    public GameObject ProjectileSpawner;
    public AudioClip FireSound;

    private float fireDownCounter = 0.0f;


    public void UpdateCannon()
    {
        rotation();
        fire();
    }


    private void rotation()
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

    private void fire()
    {
        if (Input.GetButtonDown("Jump"))
            fireDownCounter = Time.time;
        
        if (Input.GetButton("Jump"))
            Debug.Log("Charging up: " + firePower());

        if (Input.GetButtonUp("Jump"))
        {
            float firePower = this.firePower();
            Debug.Log("Charged up for: " + (Time.time - fireDownCounter) + " seconds. " + "Fired at power: " + firePower);

            GameObject firedProjectile = Instantiate(Projectile, ProjectileSpawner.transform.position, ProjectileSpawner.transform.rotation) as GameObject;
            firedProjectile.GetComponent<Rigidbody>().AddForce(firedProjectile.transform.up * firePower, ForceMode.Impulse);

            SoundManager.Instance.PlaySingle(FireSound);

            fireDownCounter = 0.0f;
        }
    }

    private float firePower()
    {
        float fireDownTime = Time.time - fireDownCounter;

        float firePower = fireDownTime * FirePowerChargeRate;

        if (firePower > MaxFirePower)   // Clamp firing power to within max and min power
            firePower = MaxFirePower;
        if (firePower < MinFirePower)
            firePower = MinFirePower;

        return firePower;
    }
}
