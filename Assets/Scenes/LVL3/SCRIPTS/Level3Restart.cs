using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level3
{
    public class Level3Restart : MonoBehaviour
    {
        public void RestartCurrentScene()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Assets/Scenes/LVL3/LEVEL 3.unity");
        }
    }
}
