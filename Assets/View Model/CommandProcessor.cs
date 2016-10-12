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



public delegate void aDisplayer(String value);

public class CommandProcessor
{
    public CommandProcessor()
    {
    }

    public void Parse(String pCmdStr, aDisplayer display)
    {
        String strResult = "Do not understand";

        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        // process the tokens
        if (parts.Length > 0) // Check incase nothing was entered
            switch (parts[0])
            {
                case "pick":
                    if (parts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        strResult = "Got Pick up";

                        if (parts.Length == 3)
                        {
                            String param = parts[2];
                        }// do pick up command
                         // GameModel.Pickup();
                    }
                    break;
                case "go":
                    switch (parts[1])
                    {
                        case "north":
                            Debug.Log("Got go North");
                            // strResult = "Got Go North";
                            GameModel.go(GameModel.DIRECTION.North);

                            break;
                        case "south":
                            Debug.Log("Got go South");
                            strResult = "Got Go South";
                            break;
                        default:
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;
                    }// end switch

                    strResult = GameModel.currentPlayer.CurrentScene.Description;
                    display(strResult);
                    break;
                default:
                    Debug.Log("Do not understand");
                    strResult = "Do not understand";
                    break;

            }// end switch

        // return strResult;

    }// Parse
}



