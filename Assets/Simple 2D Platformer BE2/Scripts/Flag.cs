using UnityEngine;

namespace SimplePlatformer
{
public class Flag : MonoBehaviour
{
    public GameObject winUI;

 private void OnTriggerEnter2D(Collider2D collision)
    {
        SimplePlatformer.PlayerMovement playerMovement = collision.GetComponentInParent<SimplePlatformer.PlayerMovement>();

        if (playerMovement != null)
        {
            Time.timeScale = 0f;
            if (winUI != null)
            {
                winUI.SetActive(true);
            }
        }
    }
}
}
