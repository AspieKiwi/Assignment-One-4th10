using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Game
{
    private int _Id;
    private string _Name;
    private static List<Game> allGames = new List<Game>();
    private Game _connected_game = new Game();


    // get set of game name
    public string Name
    {
        get
        {
            return _Name;
        }

        set
        {
            _Name = value;
        }
    }


    // get set of game id
    public int Id
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


    // get set of game connected
    public Game Connected_game
    {
        get
        {
            return _connected_game;
        }

        set
        {
            _connected_game = value;
        }
    }


    // get set for AllGames List
    public static List<Game> AllGames
    {
        get
        {
            return allGames;
        }

        set
        {
            allGames = value;
        }
    }


    // adds game to list
    public Game()
    {
        Game.AllGames.Add(this);
    }
}
