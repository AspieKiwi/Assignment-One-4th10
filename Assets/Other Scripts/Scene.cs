//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.
using System;


//A class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// private is access limited to the containing type.
// public is easily accessable.


// Scene is a Class.
// Players is a Class.
// private Players _players is a variable given the value of new Players without any parameters.
// private Scene[] _connected_scenes is a variable given the value of new Scene[4];
// private string _description is a string variable given the value of "default".
// a private string called _scenename is defined.
// public string Scenename has a get which returns the _scenename string and sets the _scenename value.
// public string Description has a get which returns the _description string and sets the _description value.

public class Scene{
		private Players _players = new Players();
		private Scene[] _connected_scenes = new Scene[4];
		private string _description = "Can't go this way";
        private string _scenename;

        public string Scenename{
            get
                {
                    return _scenename;
                }
            set
                {
                    _scenename = value;
                }
        }
    
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

        public Scene North { 
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
        public Scene South { 
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




//Here I have started working on seeing if I can create interaction with NPCs but so far it has not worked but
// I thought I would keep the proof that I have tried :)

    //    public Scene Excuse{
    //      get
    //          {
    //              return _connected_scenes[(int)GameModel.WORD.Excuse];
    //          }
    //      set
    //          {
    //              _connected_scenes[(int)GameModel.WORD.Excuse] = value;
    //          }
    //}


}


