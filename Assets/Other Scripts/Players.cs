using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// sets up a list of Player
public class Players
{
    private List<Player> _players = new List<Player>();

    //gets and sets a player index
	public Player this[int index]
    {
        get
        {
            return  _players[index];
        }
        set
        {
            _players[index] = value;
        }
	}
}


