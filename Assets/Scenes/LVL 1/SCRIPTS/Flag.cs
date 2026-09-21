using UnityEngine;

namespace Level1
{
public class Flag : MonoBehaviour
{
    public GameObject winUI;

 private void OnTriggerEnter2D(Collider2D collision)
    {
        Level1.PlayerMovement playerMovement = collision.GetComponentInParent<Level1.PlayerMovement>();

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
