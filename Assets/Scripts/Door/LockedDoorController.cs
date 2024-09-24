using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class LockedDoorController : MonoBehaviour
{
    public bool lockedByPassword;

    public void OpenLockedDoor()
    {
        if(lockedByPassword)
        {
            UnityEngine.Debug.Log("Locked. Enter Password");
            return;
        }

    }
}
