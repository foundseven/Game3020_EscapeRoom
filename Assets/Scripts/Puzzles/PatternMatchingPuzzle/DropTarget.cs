using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTarget : MonoBehaviour
{
    public DraggableObject matchingObject;
    public int matchingID;
    public bool AcceptsObject(DraggableObject draggable)
    {
        return draggable == matchingObject;
    }
}
