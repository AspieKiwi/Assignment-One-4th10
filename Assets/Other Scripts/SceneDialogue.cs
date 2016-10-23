using System;
using System.Collections.Generic;

public class SceneDialogue
{
    private int _Id;
    private string _Name;
    private string _Text;
    private static List<SceneDialogue> allDialogue = new List<SceneDialogue>();
    private SceneDialogue _connected_dialogue = new SceneDialogue();


    // gets and sets the SceneDialogue ID
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


    // gets and sets the SceneDialogue Name
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


    // gets and sets the SceneDialogue Text
    public string Text
    {
        get
        {
            return _Text;
        }

        set
        {
            _Text = value;
        }
    }


    // get and sets the Connected_dialogue for the data service

    public SceneDialogue Connected_dialogue
    {
        get
        {
            return _connected_dialogue;
        }

        set
        {
            _connected_dialogue = value;
        }
    }


    // gets and sets the AllDialogue list
    public static List<SceneDialogue> AllDialogue
    {
        get
        {
            return allDialogue;
        }

        set
        {
            allDialogue = value;
        }
    }


    // adds SceneDialogue to the AllDialogue List
    public SceneDialogue()
    {
        SceneDialogue.AllDialogue.Add(this);
    }
}
