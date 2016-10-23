using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Item
{
    private int _itemID;
    private int _sceneFindID;
    private int _sceneUseID;
    private string _name;
    private string _use;
    private string _description;
    private static List<Item> allItems = new List<Item>();

    // get set for Item ItemID
    public int ItemID
    {
        get
        {
            return _itemID;
        }

        set
        {
            _itemID = value;
        }
    }


    // get set for Item SceneFindID
    public int SceneFindID
    {
        get
        {
            return _sceneFindID;
        }

        set
        {
            _sceneFindID = value;
        }
    }


    // get set for ITem SceneUseID
    public int SceneUseID
    {
        get
        {
            return _sceneUseID;
        }

        set
        {
            _sceneUseID = value;
        }
    }

    // get set for Item Name
    public string Name
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


    // get set for Item Use
    public string Use
    {
        get
        {
            return _use;
        }

        set
        {
            _use = value;
        }
    }


    // get set for Item Description
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


    // get set for item list.
    public static List<Item> AllItems
    {
        get
        {
            return allItems;
        }

        set
        {
            allItems = value;
        }
    }

    // adds item to AllItems List
    public Item()
    {
      Item.AllItems.Add(this);
    }
}
