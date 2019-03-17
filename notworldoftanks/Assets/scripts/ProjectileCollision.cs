using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.GetComponentInParent<Player>())
        {
            var playerHit = other.gameObject.GetComponent<Player>();

            if (playerHit == null)
            {
                playerHit = other.gameObject.GetComponentInParent<Player>();
            }

            playerHit.CurHitPoints -= 20;
        }
        // Hit the ground, explosion, destroy part of platform
        Destroy(gameObject);
    }
}
