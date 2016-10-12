using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Password : MonoBehaviour
{

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

        // this line could also work

        // input.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }
}