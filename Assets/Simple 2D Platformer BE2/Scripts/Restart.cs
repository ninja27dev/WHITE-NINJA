using UnityEngine;

namespace SimplePlatformer
{
    public class Restart : MonoBehaviour
    {
        public void loadcurrentScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL 3");
            Time.timeScale = 1f;
        }
    }
}
