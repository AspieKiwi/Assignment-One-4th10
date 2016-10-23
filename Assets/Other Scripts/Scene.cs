using System;
using System.Collections.Generic;

public class Scene
{
		private Players _players = new Players();
		private Scene[] _connected_scenes = new Scene[4];
		private string _description = "Can't go this way";
        private string _scenename;
        private int _Id;
        public static List<Scene> AllScenes = new List<Scene>();

    // gets and sets Scenename
    public string Scenename
    {
        get
        {
            return _scenename;
        }
        set
        {
            _scenename = value;
        }
    }

    // gets and sets Description
    public string Description{
        get
        {
            return _description;
        }
        set
        {
            _description = value;
        }
    }


    // public Scene North has a get which returns the _connected_scenes[(int)GameModel.DIRECTION.North] and the set gives
    // _connected_scenes[(int)GameModel.DIRECTION.North] a value.

    public Scene North
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.North];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.North] = value;
        }
    }
    // public Scene South has a get which returns the _connected_scenes[(int)GameModel.DIRECTION.South] and the set gives
    // _connected_scenes[(int)GameModel.DIRECTION.South] a value.
    public Scene South
    {
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.South];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.South] = value;
        }
    }

    // public Scene West has a get which returns the _connected_scenes[(int)GameModel.DIRECTION.West] and the set gives
    // _connected_scenes[(int)GameModel.DIRECTION.West] a value.    

    public Scene West{
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.West];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.West] = value;
        }
    }

    // public Scene East has a get which returns the _connected_scenes[(int)GameModel.DIRECTION.East] and the set gives
    // _connected_scenes[(int)GameModel.DIRECTION.East] a value. 
    public Scene East{
        get
        {
            return _connected_scenes[(int)GameModel.DIRECTION.East];
        }
        set
        {
            _connected_scenes[(int)GameModel.DIRECTION.East] = value;
        }
    }
    // sets and gets ID
    public int ID
    {
        get
        {
            return _Id;
        }

        set
        {
            _Id = value;
        }
    }

    // adds scenes to allScenes
    public Scene()
    {
        Scene.AllScenes.Add(this);
    }

}


