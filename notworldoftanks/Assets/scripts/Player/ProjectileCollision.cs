using UnityEngine;


public class ProjectileCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.GetComponentInParent<Player>())
        {
            Player playerHit = other.gameObject.GetComponent<Player>();

            if (playerHit == null)
                playerHit = other.gameObject.GetComponentInParent<Player>();

            playerHit.CurHitPoints -= 20;
        }

        Destroy(gameObject);   // TODO: when we hit the ground destroy part of it and also explode
    }
}
