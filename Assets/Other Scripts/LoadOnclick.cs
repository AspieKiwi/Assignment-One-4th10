using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// used to load the next scene, useful for the log in portion of the game.
public class LoadOnclick : MonoBehaviour
{

	public void LoadScene(string pSceneName)
    {
		SceneManager.LoadScene(pSceneName);
	}
}
