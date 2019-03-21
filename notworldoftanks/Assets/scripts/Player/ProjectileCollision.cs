using UnityEngine;


public class ProjectileCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.GetComponentInParent<Player>())
        {
            Player playerHit = other.gameObject.GetComponent<Player>();

            if (playerHit == null)
                playerHit = other.gameObject.GetComponentInParent<Player>();

            playerHit.CurHitPoints -= 20;
        }

        Destroy(gameObject);
    }
}
