using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public delegate void aDisplayer(String value);


// when a command is input into the input box, the command processor takes this command into 
// a switch which then sends back to the gameModel that this specific command has been entered.
// such as Go North. 
public class CommandProcessor
{
    public CommandProcessor()
    {
    }

    public void Parse(String pCmdStr, aDisplayer display)
    {
        String strResult = "Do not understand";

        char[] charSeparators = new char[] { ' ' };
        pCmdStr = pCmdStr.ToLower();
        String[] parts = pCmdStr.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries); // tokenise the command

        // process the tokens
        if (parts.Length > 0) // Check incase nothing was entered
            switch (parts[0])
            {
                case "pick":
                    if (parts[1] == "up")
                    {
                        Debug.Log("Got Pick up");
                        strResult = "Got Pick up";
                        //var itemsinscene = Item.AllItems.Find(x => x.SceneFindID = GameModel.currentPlayer.CurrentScene.ID);
                        //if itemsinscene = 
                    }
                    break;
                case "go": // here is when the case in the switch is go
                    switch (parts[1])
                    {
                        case "north": // this is triggered if it is North
                            Debug.Log("Got go North");
                            GameModel.go(GameModel.DIRECTION.North);
                            break;
                        case "south": // this is triggered if it is South
                            Debug.Log("Got go South");
                            GameModel.go(GameModel.DIRECTION.South);
                            break;
                        case "east":// this is triggered if it is East
                            Debug.Log("Got go East"); 
                            GameModel.go(GameModel.DIRECTION.East);
                            break;
                        case "west": // this is triggered if it is West
                            Debug.Log("Got go West");
                            GameModel.go(GameModel.DIRECTION.West);
                            break;
                        default: // this is triggered if they enter in a different command next to the go
                            Debug.Log(" do not know how to go there");
                            strResult = "Do not know how to go there";
                            break;
                    }// end switch

                    strResult = GameModel.currentPlayer.CurrentScene.Description;
                    display(strResult);
                    break;
                    default:
                    Debug.Log("Do not understand"); // this is triggered if it does not understand your input
                    strResult = "Do not understand";
                    break;

            }// end switch

        // return strResult;

    }// Parse
}



