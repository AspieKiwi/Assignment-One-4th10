//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)

// UnityEngine is a collection of all the classes related to Unity.
// UnityEngine.SceneManagement is a namespace that contains Classes like SceneManagement and Scene.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// public keyword is an access modifier for types and type members. It's the most permissive access level.
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// LoadOnclick is a Class.
// MonoBehaviour is the base class every script derives from.
// when used as the return type or a method, void specifies that the method doesn't return a value. 
// void isn't allowed in the parameter list of a method. 
// LoadScene is a public void with the parameters of string and pSceneName.
// SceneManager is the Scene Management at run-time.
// SceneManager.LoadScene has the parameter of pSceneName.

public class LoadOnclick : MonoBehaviour {

	public void LoadScene(string pSceneName){
		SceneManager.LoadScene(pSceneName);
	}
}
