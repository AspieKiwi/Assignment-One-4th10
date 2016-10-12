// using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.
// UnityEngine is a collection of all the classes related to Unity.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
// System.Collections.Generic namespace contains interfaces and classes that define generic collections.
// System.IO namespace contains types that allow reading and writing to files and data streams,
// and types that provide basic file and directory support.
// System.Text namespace contains classes that represent ASCII and Unicode character encodings.

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

// public keyword is an access modifier for types and type members. It's the most permissive access level.
// there are no restrictions on accessing public members.
// Use the static modifier to declare a static member, which belongs to the type itself rather than to a specific object. 
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// GameModel is a public static class.
// private is access limited to the containing type.
// string type represents a sequence of zero or more Unicode characters. 
// private static string is defined and given the name _name.
// private static Player is defined and given the name _player, it is then given the value of a new Player.
// enum keyword is used to declare an enumeration, a distinct type that consists of a set of named constants called the enumerator list.
// public enum DIRECTION has a list containing North, South, East and West;
// private static Scene is defined and given the name _start_scene.
// public static Players is defined and given the name PlayersInGame and given the value of new Players.
// public static Scene Start_scene does a get and a set, the get does a return _start_scene and the set gives the _start_scene a value.
// public static string Name does a get and a set, the get returns _name the set gives _name a value.
// public static Player currentPlayer does a get and a set, the get returns _player the set gives _player a value.


public static class GameModel
{

    private static String _name;
    private static Player _player = new Player();
    public enum DIRECTION { North, South, East, West };
    private static Scene _start_scene; // ??
    public static Players PlayersInGame = new Players();

    public static Scene Start_scene
    {
        get
        {
            return _start_scene;
        }
        set
        {
            _start_scene = value;
        }

    }

    public static string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }

    }

    public static Player currentPlayer
    {
        get
        {
            return _player;
        }
        set
        {
            _player = value;
        }

    }
    public static void go(DIRECTION pDirection)
    {
        currentPlayer.Move(pDirection);
    }

    public static void makeScenes()
    {
        Scene tmp;
        DataService theService = new DataService();

        // uncomment the following two lines to start with an empty database
        //if(theService.DbExists("GameNameDb"))
      // theService.deleteDatabaseFile();

        // Watch out DbExists has a side effect!
        if (theService.DbExists("GameNameDb"))
        {
            theService.Connect();
            theService.LoadScenes();
            currentPlayer.InitialisePlayerState();
            currentPlayer.CurrentScene = Scene.AllScenes[0];
        }
        else
        {

            Start_scene = new Scene();
            Start_scene.Scenename = "TextIO";

            tmp = new Scene();
        Start_scene.ID = 1;
        Start_scene.North = tmp;
        Start_scene.West = tmp;
        Start_scene.South = tmp;
        Start_scene.East = tmp;
        Start_scene.Description = "You are at the front of the class with your teacher" ;


        tmp.ID = 2;
        tmp.Description = "You walk back to your desk";
        //tmp.Excuse = new Scene(); // working on this excuse path
        tmp.South = new Scene();
        tmp.East = new Scene();
        tmp.West = new Scene();
        tmp.North = new Scene();

        tmp.North.ID = 3;
        tmp.North = new Scene ();
        tmp.North.Description = "You fell on your desk";
        tmp.North.South = tmp;		
		tmp.North.North = new Scene();
        tmp.North.West = new Scene();
        tmp.North.East = new Scene();

            tmp.North.North.ID = 4;
        tmp.North.North.Description = "You can't go this way";
        tmp.North.North.South = tmp.North;


            tmp.North.West.ID = 5;
        tmp.North.West.Description = "You can't go this way";
        tmp.North.West.East = tmp.North;

            tmp.North.East.ID = 6;
        tmp.North.East.Description = "You can't go this way";
        tmp.North.East.West = tmp.North;


            tmp.West.ID = 7;
        tmp.West.Description = "You fell out the window";
        tmp.West.North = new Scene();
        tmp.West.South = new Scene();
        tmp.West.East = tmp;
        tmp.West.West = new Scene();

            tmp.West.North.ID = 8;
        tmp.West.North.Description = "You can't go this way";
        tmp.West.North.South = tmp.West;

            tmp.West.South.ID = 9;
        tmp.West.South.Description = "You can't go this way";
        tmp.West.South.North = tmp.West;

            tmp.West.West.ID = 10;
        tmp.West.West.Description = "You can't go this way";
        tmp.West.West.East = tmp.West;

            tmp.East.ID = 11;
        tmp.East.Description = "You walk into your teacher";
        tmp.East.West = tmp;
        tmp.East.South = new Scene();
        tmp.East.North = new Scene();
        tmp.East.East = new Scene();

            tmp.East.South.ID = 12;
        tmp.East.South.Description = "You can't go this way";
        tmp.East.South.North = tmp.East;

            tmp.East.North.ID = 13;
        tmp.East.North.Description = "You can't go this way";
        tmp.East.North.South = tmp.East;

            tmp.East.East.ID = 14;
        tmp.East.East.Description = "You can't go this way";
        tmp.East.East.West = tmp.East;

            tmp.South.ID = 15;
        tmp.South.Description = "You sit on your chair";
        tmp.South.East = new Scene();
        tmp.South.North = tmp;
        tmp.South.West = new Scene();
        tmp.South.South = new Scene();

            tmp.South.East.ID = 16;
        tmp.South.East.Description = "You can't go this way";
        tmp.South.East.West = tmp.South;

            tmp.South.West.ID = 17;
        tmp.South.West.Description = "You can't go this way";
        tmp.South.West.East = tmp.South;

            tmp.South.South.ID = 18;
        tmp.South.South.Description = "You can't go this way";
        tmp.South.South.North = tmp.South;

            currentPlayer.InitialisePlayerState();
            currentPlayer.CurrentScene = Start_scene;


            theService.Connect();
            theService.SaveScenes();
        }

    }


}


