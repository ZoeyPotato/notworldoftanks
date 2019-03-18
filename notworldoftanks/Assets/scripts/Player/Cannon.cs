using UnityEngine;
using System;


public class Cannon : MonoBehaviour
{
    public float RotateSpeed = 50;
    public float CurAngle = 0;
    public float MaxAngle = 90;
    public float MinAngle = -10;

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
                    amountToRotate = MaxAngle - CurAngle;   // TODO: math.abs this shit too

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
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
        {
            SoundManager.Instance.PlaySingle(fireSound1);

            Instantiate(projectile, projectileSpawner.transform.position, projectileSpawner.transform.rotation);
        }
    }
}
