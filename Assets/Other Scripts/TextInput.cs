//using imports namespace. (Namespace is a collection of classes and other data types that are used to categorize the library.)

// UnityEngine is a collection of all the classes related to Unity.
// System.Collections is all the classes in .Net related to holding groups of data such as hashtable and array list.
// They are required whenever you use a class in that namespace.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


// public keyword is an access modifier for types and type members. It's the most permissive access level.
// there are no restrictions on accessing public members.
// class is a construct that enables you to create your own custom types by grouping together variables of other types, methods and events.
// MonoBehaviour is the base class every script derives from.
// Inputfield turns a label into an interactible field.
// Inputfield.SumbitEvent is a Unity event with a inputfield as a param.
// OnChangeEvent is the callback sent anytime the InputField is updated.
// when used as the return type or a method, void specifies that the method doesn't return a value. 
// void isn't allowed in the parameter list of a method. 
// String represents text as a sequence of UTF-16 code units.

// TextInput is a Class.
// MonoBehaviour is a class within UnityEngine.
// InputField is a class within UnityEngine.UI.
// An InputField called Input is defined
// SumbitEvent is a class within UnityEngine.UI.InputField.
// An InputField.SubmitEvent called se is defined.
// OnChangeEvent is a class within UnityEngine.UI.InputField.
// An InputField.OnChangeEvent called ce is defined.
// Text is a class within UnityEngine.UI.
// A public Text called output is defined.
// output.text triggers a get set. It is the string value that aStr will be set to.


public class TextInput : MonoBehaviour {
	InputField input;
	InputField.SubmitEvent se;
	InputField.OnChangeEvent ce;
	public Text output;


    public void TextUpdate(string aStr){
	    output.text = aStr;
    }



// when used as the return type or a method, void specifies that the method doesn't return a value.
// void isn't allowed in the parameter list of a method.
// input is the interface to the input system.
// this.GetComponent is the type of Component we are retreiving. In this instance because there is nothing in the brackets
// the GetComponent will return a null instead of a (Type type).
// Inputfield turns a label into an interactible field.
// Inputfield.SumbitEvent is a Unity event with a inputfield as a param.
// AddListener adds a non persistent listener to the UnityEvent. Using it adds a runtime callback. The parameter is a callback function. 
// In this instance the call back function is SubmitInput.
// input.onEndEdit is a Unity event to call when editing has ended. 
// output.text is set to the Description related to the CurrentScene and CurrentPlayer within the GameModel.


// input is a field of TextInput.
// this indicates towards TextInput as it points to the class it is currently in.
// GetComponent gets the InputField without parameters.
// InputField is a class of The UnityEngine.UI Class.
// input is set to GetComponent of InputField.
// se is a field of TextInput.
// se is set to being a new InputField.SubmitEvent.
// se.AddListener calls a Listner with the SubmitInput parameter.
// input.onEndEdit = se sets if input.onEndEdit is used then the newInputField.SubmitEvent will occur.
// output.text is set to equal GameModel.currentPlayer.CurrentScene.Description;
// Gamemodel is a class.
// currentPlayer is of both Gamemodel and Player and has a get set.
// CurrentScene is of both Scene and Player and has a get set.
// Description is a String within the Scene with a get set.


    void Start () {
	    input = this.GetComponent<InputField>();
	    se = new InputField.SubmitEvent();
	    se.AddListener(SubmitInput);
	    input.onEndEdit = se;
	    output.text = GameModel.currentPlayer.CurrentScene.Description;
    }


// private is access limited to the containing type.
// when used as the return type or a method, void specifies that the method doesn't return a value.
// void isn't allowed in the parameter list of a method.
// ActiveInputField is a function to activate the InputField to begin processing Events.
// In output.text, text is the string value the text will display.

// SubmitInput takes parameters of string and arg0.
// String is a Class of the System Class.
// currentText is a local varible of type string that is set to output.text;
// output is a field within TextInput.
// CommandProcessor is a Class.
// aCmd is a local varible of CommandProcessor
// new CommandProcessor creates a new instance of the CommandProcessor.
// aCMD.Parse sends parameters to the Parse method within Command procesor. The parameters are arg0, and TextUpdate);
// Input is a field within TextInput. text is the current value of the field.
// ActivateInputField Activates the input field to allow it to begin processing requests.




    private void SubmitInput(string arg0) {
		string currentText = output.text;
		CommandProcessor aCmd = new CommandProcessor();
		aCmd.Parse(arg0,TextUpdate);

		input.text = "";
		input.ActivateInputField();
	}


// private is access limited to the containing type.
// when used as the return type or a method, void specifies that the method doesn't return a value.
// void isn't allowed in the parameter list of a method.
// Debug is a class containing methods to ease debugging while developing a game.
// Log sends a message to the Unity Engine Console

// ChangeInput takes a String and Arg0
// String is a Class within the System Class.
// arg 0 is a parameter taken along with the string in this instance.
// Debug is a class within the UnityEngine Class.
// In this instance, log is used to send a message for the Debug Class, taking the arg0 and turning it into a string.


    private void ChangeInput( string arg0)
    {
	    Debug.Log(arg0);
    }
}
