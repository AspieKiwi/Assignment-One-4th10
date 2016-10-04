// using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)
// The System namespace contains fundamental classes and base classes that define commonly-used value and reference data types,
// events and event handlers, interfaces, attributes, and processing exceptions.

using System;

// public keyword is an access modifier for types and type members. It's the most permissive access level.
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// Player is a Class.
// private is access limited to the containing type.
// Use the static modifier to declare a static member, which belongs to the type itself rather than to a specific object. 
// int keyword denotes an integral type
// private static int _player_number is set to equal to 0.
// private int _number is set to equal the _player_number within player.
// string type represents a sequence of zero or more Unicode characters.
// a private string is created that is given the name, _name
// a private type of class Item[] called _inventory is created, but this wont be used to later on.
// a private type of class Scene called _currentScene is created.
// public Scene CurrentScene has a get that returns the _currentScene and a set that gives a value to the _currentScene.
// public String Name has a get that returns the _name and a set that gives a value to the _name. _name is a string.
// public void Move has the parameters of GameModel.DIRECTION and pDirection.
// GameModel.DIRECTION is from the GameModel Class.
// pDirection is a variable set in the GameModel.DIRECTION.
// switch statement is a control statement that selects a switch section to execute from a list of candidates.
// switch statement includes one or more switch sections. Each switch section contains one or more case labels followed by one or more statements. 
// a switch is set with a parameter of the pDirection.
// then a case of if the pDirection = North. (GameModel.DIRECTION.North).
// an if statement follows checking if _currentScene.North is not equal to null then the _currentScene is set to equalling _currentScene.North.
// break statement terminates the closest enclosing loop or switch statement in which it appears. Control is passed to the statement that follows the terminated statement, if any.
// a break is then set after this if statement.
// then a similar case is set with the pDirection equal to South.
// another similar if statement is used with _currentScene eventually equaling to _currentScene.South.
// another break is used.



public class Player	{
	// Class
	private static int _player_number = 0;
		
	// Instance
	private int _number = (Player._player_number++); 
	private string _name;
	private Item[] _inventory; 
	private Scene _currentScene;

    public void InitalizePlayerState()
    {
        Persist.control.Experience = 0;
        Persist.control.Health = 5;
    }

    public Player()
    {
        InitalizePlayerState();
    }
	   
	public Scene CurrentScene{ 
		get
            {
			    return _currentScene;
		    } 
		set
            {
			    _currentScene = value;
		    }
	}

	public String Name{ 
		get
            {
			    return _name;
		    } 
		set
            {
			    _name = value;
		    }
	}
    private void AddExperience()
    {
        Persist.control.Experience = Persist.control.Experience + 1;
    }

	public void Move(GameModel.DIRECTION pDirection){
        
		switch(pDirection){
			case GameModel.DIRECTION.North: // but what do we do??
				if( _currentScene.North != null)
					{
						_currentScene =  _currentScene.North;
                    AddExperience();
					}
				break;
			case GameModel.DIRECTION.South:
                if (_currentScene.South != null)
                    {
                        _currentScene = _currentScene.South;
                    }
                break;
			case GameModel.DIRECTION.East:
                if (_currentScene.East != null)
                {
                    _currentScene = _currentScene.East;
                }
                break;
			case GameModel.DIRECTION.West:
                if (_currentScene.West != null)
                {
                    _currentScene = _currentScene.West;
                }
                break;
		}
	}


// this is where I was working on adding in NPC communication. So far it doesn't work yet.
    //    public void Say(GameModel.WORD pWord)
    //{
    //    if (_currentScene.Excuse != null)
    //    {
    //        _currentScene = _currentScene.Excuse;
    //    }
    //}
	//	public Player ()
	//	{
	//	}
	}


