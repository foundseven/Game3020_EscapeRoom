using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public DoorController door;
    public string _password;
    public int _passwordLimit;
    public Text _passwordText;

    //audio

    private void Start()
    {
        _passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {

    }
    private void Clear()
    {

    }

    private void Enter()
    {

    }
}
