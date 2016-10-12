//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.

using System;

// this is in preparation of the item use eventually being added to the game. 
	public class Item
	{
		[PrimaryKey, AutoIncrement]
		public int ItemID {get; set;}
		public int SceneFindID {get; set;}
		public int SceneUseID {get; set;}
		public string Name {get; set;}
		public string Use {get; set;}
		public string Description {get; set;}

	}
	
// what else to do in this class??


