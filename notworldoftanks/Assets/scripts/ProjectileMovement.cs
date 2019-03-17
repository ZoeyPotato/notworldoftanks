using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float thrust = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * thrust, ForceMode.Impulse);
    }
}
