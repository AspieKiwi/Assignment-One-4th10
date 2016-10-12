using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LogIn : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public Text pUsername;
    public Text pPassword;
    public InputField.SubmitEvent se;
    public InputField.SubmitEvent sv;
    public InputField.OnChangeEvent ce;



    public void TextUpdate (string pStrName, string pPassword)
    {
        Username.text = pStrName;
        Password.text = pPassword;
    }

    void Start()
    {
        Username = this.GetComponent<InputField>();
        Password = this.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        sv = new InputField.SubmitEvent();
        //se.AddListener(SubmitInput);
       // sv.AddListener(SubmitInput);
        Username.onEndEdit = se;
        Password.onEndEdit = sv;

    }

    private void SubmitInput(string pUsername, string pPassword)
    {
        DataService theService = new DataService();

       if (theService.CheckPassword(pUsername, pPassword))

        {

       }
    }

}
