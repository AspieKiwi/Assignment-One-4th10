using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GamePerson
{
    private int _personID;
    private int _gameID;
    private string _description;
    private static List<GamePerson> allGamePersons = new List<GamePerson>();
    private GamePerson _connected_gameperson = new GamePerson();


    // gets and sets the PersonID that is joined to a game
    public int PersonID
    {
        get
        {
            return _personID;
        }

        set
        {
            _personID = value;
        }
    }


    // gets and sets the GameID that is joined to a person
    public int GameID
    {
        get
        {
            return _gameID;
        }

        set
        {
            _gameID = value;
        }
    }


    // gets and sets the connected_gameperson this is required for the data service
    public GamePerson Connected_gameperson
    {
        get
        {
            return _connected_gameperson;
        }

        set
        {
            _connected_gameperson = value;
        }
    }


    // gets and sets the Description of the Game Person (For the data service I needed a string it wouldn't work with an int)
    public string Description
    {
        get
        {
            return _description;
        }

        set
        {
            _description = value;
        }
    }

    // get set for AllGamePersons list
    public static List<GamePerson> AllGamePersons
    {
        get
        {
            return allGamePersons;
        }

        set
        {
            allGamePersons = value;
        }
    }

    // adds a gameperson to the list.
    public GamePerson()
    {
        GamePerson.AllGamePersons.Add(this);
    }
}
