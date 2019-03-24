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

            var hitDmg = Random.Range(10, 20);
            playerHit.CurHitPoints -= hitDmg;
        }

        Destroy(gameObject);
    }
}
