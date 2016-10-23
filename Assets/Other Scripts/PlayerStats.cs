using System;
using System.Collections.Generic;


public class PlayerStats
{
    private int _Id;
    private string _StatusName;
    private string _Changed;
    private int _Value;
    private static List<PlayerStats> allStats = new List<PlayerStats>();
    private PlayerStats _connected_stats = new PlayerStats();


    // gets and sets the PlayerStats ID
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


    // gets and sets the PlayerStats StatusName
    public string StatusName
    {
        get
        {
            return _StatusName;
        }

        set
        {
            _StatusName = value;
        }
    }


    // gets and sets the PlayerStats Changed
    public string Changed
    {
        get
        {
            return _Changed;
        }

        set
        {
            _Changed = value;
        }
    }


    // gets and sets the PlayerStats Value
    public int Value
    {
        get
        {
            return _Value;
        }

        set
        {
            _Value = value;
        }
    }


    // gets and sets the Connected_stats which is needed for data service
    public PlayerStats Connected_stats
    {
        get
        {
            return _connected_stats;
        }

        set
        {
            _connected_stats = value;
        }
    }

    // gets and sets the AllStats List
    public static List<PlayerStats> AllStats
    {
        get
        {
            return allStats;
        }

        set
        {
            allStats = value;
        }
    }

    // adds the Player stats to the all stats list.
    public PlayerStats()
    {
        PlayerStats.AllStats.Add(this);
    }
}