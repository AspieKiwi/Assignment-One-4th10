using System;

[Serializable]
public class Player
{
    // Class
    //private static int _player_number = 0;

    // Instance
    //private int _number = (Player._player_number++);
    private string _name;
    private Item[] _inventory;  
    public Scene _currentScene;

    // returns and sets the current Scene
    public Scene CurrentScene
    {
        get
        {
            return _currentScene;
        }
        set
        {
            _currentScene = value;
        }
    }

    // returns and sets a name
    public String Name
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

    // adds expierence using the persist
    private void AddExperience()
    {
        Persist.control.Experience = Persist.control.Experience + 1;
    }

    // where the player has moved to within the gameModel
    public void Move(GameModel.DIRECTION pDirection)
    {

        switch (pDirection)
        {
            case GameModel.DIRECTION.North: // but what do we do??
                if (_currentScene.North != null)
                {
                    _currentScene = _currentScene.North;
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

    // initialisation of the player state of persist
    public void InitialisePlayerState()
    {
        if (Persist.control != null)
        {
            Persist.control.Experience = 10;
            Persist.control.Health = 5;
        }
    }


    // triggers the above initalisation 
    public Player()
    {
        InitialisePlayerState();
    }
}



