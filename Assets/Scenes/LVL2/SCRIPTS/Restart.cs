using UnityEngine;

namespace Level2
{
    public class Restart : MonoBehaviour
    {
        public void loadcurrentScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LEVEL 2");
            Time.timeScale = 1f;
        }
    }
}
