using UnityEngine;
using System.Collections;

public class CameraRoot : MonoBehaviour
{
    void Awake()
    {
		DontDestroyOnLoad(gameObject);
	}

// void start uses makeScenes from the GameModel Class.
	void Start ()
    {
		GameModel.makeScenes();
	}
	
// Update is called once per frame
	void Update ()
    {
	
	}
}
