//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.
// UnityEngine is a collection of all the classes related to Unity.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
// System.Collections.Generic namespace contains interfaces and classes that define generic collections.
// System.IO namespace contains types that allow reading and writing to files and data streams,
// and types that provide basic file and directory support.

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


// public keyword is an access modifier for types and type members. It's the most permissive access level.
// there are no restrictions on accessing public members.
// delegate is a type that represents references to methods with a particular parameter list and return type.
// when used as the return type or a method, void specifies that the method doesn't return a value.
// void isn't allowed in the parameter list of a method.
// public delegate void aDisplayer is created and it takes a parameter of String and value.
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// CommandProcessor is a public class.
// public void Parse has the parameters of String pCmdStr and aDisplayer display.
// a string is created and given the name strResult and the value of = "Do not understand".
// char keyword is used to declare an instance of the System.Char structure that the .NET Framework uses to represent a Unicode character.
// a char is created which is given the name charSeparators and given the value of new char[] {' '}
// pCmdStr is given the value of pCmdStr.ToLower.
// a string is created and given the name parts. It's then given the value of pCmdStr.Split(charSeparators,StringSplitOptions.RemoveEmptyEntries)




public delegate void aDisplayer( String value );


public class CommandProcessor{
	public CommandProcessor ()
		{
		}

    public void Parse(String pCmdStr, aDisplayer display){  
	    String strResult = "Do not understand"; 

	    char[] charSeparators = new char[] {' '};
	    pCmdStr = pCmdStr.ToLower();
	    String[] parts = pCmdStr.Split(charSeparators,StringSplitOptions.RemoveEmptyEntries); 
        
// switch statement is a control statement that selects a switch section to execute from a list of candidates.
// switch statement includes one or more switch sections. Each switch section contains one or more case labels followed by one or more statements. 
// a switch is created that reads parts[0] which is the first part of the text input. 1 is the second part of the input.
// a case of "pick" being parts[0] is created which will be used later to define the inventory actions.	    
        switch ( parts[0]){
			case "pick" : 
				if( parts[1] == "up") {
					Debug.Log("Got Pick up");
					strResult = "Got Pick up";

					if( parts.Length == 3){
						String param = parts[2];
					}
		        }
					break;
// this here is where I am working on bringing in actions towards NPCs.
            //case "do":
            //    switch(parts[1])
            //    {
            //        case "excuse":
            //            Debug.Log("Got Do Excuse");
            //            GameModel.word(GameModel.WORD.Excuse);
            //            break;
            //    }
            //    break;


// here a case of go is created. this handles the directions with the second switch representing the direction that the player has chosen
// to go in. (such as north, south, east and west.
			case "go" : 
				switch( parts[1]) {
					case "north": 
					    Debug.Log("Got go North");
						GameModel.go(GameModel.DIRECTION.North);
				            
						break;
					case "south": 
						Debug.Log("Got go South");
                        GameModel.go(GameModel.DIRECTION.South);

                        break;
                    case "west":
                        Debug.Log("Got go West");
                        GameModel.go(GameModel.DIRECTION.West);
                        break;

                    case "east":
                        Debug.Log("Got go East");
                        GameModel.go(GameModel.DIRECTION.East);

                        break;

                    default: 
						Debug.Log(" do not know how to go there"); 
						strResult = "Do not know how to go there";

						break;
				}
						
		    strResult = GameModel.currentPlayer.CurrentScene.Description;
		    display(strResult);

		    break;


		default:
			Debug.Log("Do not understand");
			strResult = "Do not understand";

			break;
			         
	    }
	}
}


