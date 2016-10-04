//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
// System.Collections.Generic namespace contains interfaces and classes that define generic collections.
// System.IO namespace contains types that allow reading and writing to files and data streams,
// and types that provide basic file and directory support.



using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


// A class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// Players is a Class
// private list<Player> _players is set to create a new List of Players.
// Player Class gets an index of the _players using a get to get the _players[index] and a set to set _player[index] value.
public class Players{
    private List<Player> _players = new List<Player>();

	public Player this[int index] {
			get
			    { 
				    return  _players[index];
			    } 
			set
			    {
				    _players[index] = value;
			    }
	}

	//    public Players ()
	//	{
		
	//	}
}


