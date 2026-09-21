using UnityEngine;

namespace SimplePlatformer
{
public class StartNew : MonoBehaviour
{
    public void loadcurrentScene()
    {
    
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene lvl 1");
        Time.timeScale = 1f;    
    }
}
}
