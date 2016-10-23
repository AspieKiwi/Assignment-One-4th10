using System.Collections;
using UnityEngine;

// Runs only once and destroyeds a game object then triggers the gamemodel's make scenes.
public class RunOnlyOnce : MonoBehaviour
{
	public static RunOnlyOnce instance;
	void Awake()
    {
		if(instance != null && instance != this)
        {
			DestroyImmediate(gameObject);
			return;
		}
		instance = this;
		GameModel.makeScenes();
	}
}
