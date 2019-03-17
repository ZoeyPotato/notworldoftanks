using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float thrust = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * thrust, ForceMode.Impulse);
    }
}
