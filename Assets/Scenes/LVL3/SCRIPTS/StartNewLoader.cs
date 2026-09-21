using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewLoader : MonoBehaviour
{
	public void LoadSceneByName()
	{
		SceneManager.LoadScene("Assets/Scenes/LVL 1/GameScene lvl 1.unity");
	}

	public void LoadNextInBuild()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}