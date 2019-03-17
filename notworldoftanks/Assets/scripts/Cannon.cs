using UnityEngine;
using System;


public class Cannon : MonoBehaviour
{
    public float RotateSpeed = 50;
    public float CurAngle = 0;
    public float MaxAngle = 90;
    public float MinAngle = -10;

    private Cannon cannon;


    public void Awake()
    {
        cannon = gameObject.GetComponentsInChildren<Cannon>()[0];
    }

    public void UpdateCannon()
    {
        rotation();
    }


    private void rotation()
    {
        // REFACTOR: do we like doing rotation here in the cannon class or move back to player?

        // TODO: when we hit the max or min angle the cannon SHOULD NOT stop rotating

        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            float amountToRotate = RotateSpeed * Time.deltaTime;

            if (Input.GetKey("w"))
            {
                if (CurAngle + amountToRotate >= MaxAngle)
                    amountToRotate = MaxAngle - CurAngle;

                CurAngle += amountToRotate;
                cannon.transform.Rotate(0, 0, amountToRotate);
            }

            if (Input.GetKey("s"))
            {
                if (CurAngle - amountToRotate <= MinAngle)
                    amountToRotate = Math.Abs(MinAngle) - Math.Abs(CurAngle);

                CurAngle -= amountToRotate;
                cannon.transform.Rotate(0, 0, -amountToRotate);
            }
        }
    }
}
