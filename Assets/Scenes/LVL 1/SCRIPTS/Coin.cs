using UnityEngine;

namespace Level1
{
public class Coin : MonoBehaviour
{
    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectCoin(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollectCoin(collision.collider);
    }

    private void CollectCoin(Collider2D collision)
    {
        Level1.PlayerMovement playerMovement = collision.GetComponentInParent<Level1.PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.coins += 1;
            Destroy(gameObject);
        }
    }
}
}
