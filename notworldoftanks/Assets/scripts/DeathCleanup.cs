using UnityEngine;


public class DeathCleanup : MonoBehaviour
{
    public float maxTimeAlive = 5.0f;
    private float timeAlive = 0.0f;


    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= maxTimeAlive)
            Destroy(gameObject);
    }
}
