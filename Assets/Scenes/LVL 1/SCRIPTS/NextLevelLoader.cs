using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
	public void LoadSceneByName()
	{
		SceneManager.LoadScene("Assets/Scenes/LVL2/LEVEL 2.unity");
	}

	public void LoadNextInBuild()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
