// using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.
// UnityEngine is a collection of all the classes related to Unity.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.

using UnityEngine;
using System.Collections;


// public keyword is an access modifier for types and type members. It's the most permissive access level.
// there are no restrictions on accessing public members.
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// CameraRoot is a class.
// MonoBehaviour is the base class every script derives from.
public class CameraRoot : MonoBehaviour {
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

// void start uses makeScenes from the GameModel Class.
	void Start () {
		GameModel.makeScenes();
	}
	
// Update is called once per frame
	void Update () {
	
	}
}
