using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadKey : MonoBehaviour
{
    public string keyCode;

    public void SendKey()
    {
        this.transform.GetComponentInParent<KeypadController>().PasswordEntry(keyCode);
    }
}
