using UnityEngine;

namespace Level3
{
public class Flag : MonoBehaviour
{
    public GameObject winUI;

 private void OnTriggerEnter2D(Collider2D collision)
    {
        Level3.PlayerMovement playerMovement = collision.GetComponentInParent<Level3.PlayerMovement>();

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
