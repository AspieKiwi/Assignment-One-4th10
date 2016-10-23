using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class GameModel
{
    private static String _name;
    private static Player _player = new Player();
    public enum DIRECTION { North, South, East, West };
    private static Scene _start_scene; // ??
    public static Players PlayersInGame = new Players();

    // set and get the start_scene
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

    // sets and gets the Name
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

    // sets and gets the curret Player
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

    // gets the direction and triggers the current player move
    public static void go(DIRECTION pDirection)
    {
        currentPlayer.Move(pDirection);
    }

    // creates the Scenes
    public static void makeScenes()
    {
        Scene tmp;
        DataService theService = new DataService();

        // uncomment the following two lines to start with an empty database
        if (theService.DbExists("NeverLDb"))
            theService.deleteDatabaseFile();

        // Watch out DbExists has a side effect!
        if (theService.DbExists("NeverLDb"))
        {
            theService.Connect();
            theService.LoadScenes();
            currentPlayer.InitialisePlayerState();
            currentPlayer.CurrentScene = Scene.AllScenes[0];
        }
        else
        {
            // set up of the scenes that the player can move through, including the IDs
            Start_scene = new Scene();
            Start_scene.Scenename = "TextIO";

            tmp = new Scene();

            Start_scene.ID = 1;
            Start_scene.North = tmp;
            Start_scene.West = tmp;
            Start_scene.South = tmp;
            Start_scene.East = tmp;
            var appleItem = new Item();
            appleItem.SceneFindID = Start_scene.ID;
            appleItem.Name = "Apple";
            Start_scene.Description = "You are at the front of the class with your teacher" ;

            tmp.ID = 2;
            tmp.Description = "You walk back to your desk";
            tmp.South = new Scene();
            tmp.East = new Scene();
            tmp.West = new Scene();
            tmp.North = new Scene();

            tmp.North.ID = 3;
            appleItem.SceneUseID = tmp.North.ID;
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

            // triggering of the saving of scenes and the creation of other tables and an item and a person.
            theService.Connect();
            theService.SaveScenes();
            theService.CreateDB();
            theService.CreatePerson();
            theService.CreateItem();
        }
    }
}


