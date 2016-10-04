// using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// UnityEngine is a collection of all the classes related to Unity.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
using System.Collections;
using UnityEngine;




// A class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// RunOnlyOnce is a Class
// MonoBehaviour is a Class within the UnityEngine collection.
// Use the static modifier to declare a static member, which belongs to the type itself rather than to a specific object. 
// instance is an instance of the public static RunOnlyOnce Class.
// Awake contains an if instance is not equal to null && instance not equal to this (which is The RunOnlyOnce Class) then
// destroyImmediate(gameObject) and then return. (Game object being something in the view).
// after the if the instance will now equal to the RunOnlyOnce Class and then the makeScenes method from inside the GameModel class
// will be activated without any parameters.
public class RunOnlyOnce : MonoBehaviour {
	public static RunOnlyOnce instance;
	void Awake() {
		if(instance != null && instance != this) {
			DestroyImmediate(gameObject);
			return;
		}
		instance = this;
		GameModel.makeScenes();
	}
}
