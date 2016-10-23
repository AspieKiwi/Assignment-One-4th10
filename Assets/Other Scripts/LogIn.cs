using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogIn : MonoBehaviour
{
    public Text UserName;
    public Text Password;
    public InputField.SubmitEvent se;
    public InputField.SubmitEvent sv;
    public InputField.OnChangeEvent ce;


    // the log in that takes the two input boxes and checks them within the DataService
    public void Login()
    {
        string pUsername = UserName.text;
        string pPassword = Password.text;

        DataService aDS = new DataService();
        if (aDS.DbExists("GameNameDb"))
        {
            aDS.Connect();
            if (aDS.CheckPassword(pUsername, pPassword))
            {
                SceneManager.LoadScene("TextIO");
            }
            else
            {
                Debug.Log("Incorrect Name/Password");
            }
        }
    }
}




