using UnityEngine;

namespace Level2
{
public class Flag : MonoBehaviour
{
    public GameObject winUI;

 private void OnTriggerEnter2D(Collider2D collision)
    {
        Level2.PlayerMovement playerMovement = collision.GetComponentInParent<Level2.PlayerMovement>();

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
