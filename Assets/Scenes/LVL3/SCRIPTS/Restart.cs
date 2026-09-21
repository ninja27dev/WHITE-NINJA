using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level3
{
    public class Restart : MonoBehaviour
    {
        public void loadcurrentScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
