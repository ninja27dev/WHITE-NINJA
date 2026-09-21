using UnityEngine;

namespace SimplePlatformer
{
public class nextlevel : MonoBehaviour
    {
        public string nextLevelName;
     public void nextLevel()
    {
    
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLevelName);
        Time.timeScale = 1f;    
    }
}
}