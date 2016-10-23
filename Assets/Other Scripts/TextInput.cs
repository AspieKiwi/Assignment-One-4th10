using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    InputField input;
    InputField.SubmitEvent se;
    InputField.OnChangeEvent ce;
    public Text output;

    public void TextUpdate(string aStr)
    {
        output.text = aStr; // this is where the output on the screen is set as a string
    }

    // Use this for initialization
    void Start()
    {

        input = this.GetComponent<InputField>(); // here is where the input from the user is grabbed.
        se = new InputField.SubmitEvent();
        se.AddListener(SubmitInput); 

        input.onEndEdit = se;
        output.text = GameModel.currentPlayer.CurrentScene.Description; // this is where the output text is set as a GameModel Description
     }


    private void SubmitInput(string arg0)
    {
        //string currentText = output.text;

        CommandProcessor aCmd = new CommandProcessor(); // a new command processor is made here


        aCmd.Parse(arg0, TextUpdate);

        input.text = "";
        input.ActivateInputField(); // here is where the input field is activated.
    }


    private void ChangeInput(string arg0)
    {
        Debug.Log(arg0);
    }
}
