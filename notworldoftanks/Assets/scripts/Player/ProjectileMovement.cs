using UnityEngine;


public class ProjectileMovement : MonoBehaviour
{
    public float thrust = 500.0f;


    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * thrust, ForceMode.Impulse);
    }
}
