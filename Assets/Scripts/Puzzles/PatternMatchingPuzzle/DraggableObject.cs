using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private RectTransform rectTransform;
    private Canvas canvas;
    public int matchingID;

    public delegate void DroppedHandler(DraggableObject draggable, DropTarget target);
    public event DroppedHandler OnDropped;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag started!");
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //DropTarget target = eventData.pointerEnter?.GetComponent<DropTarget>();

        //Debug.Log($"Pointer entered: {eventData.pointerEnter?.name}");


        //OnDropped?.Invoke(this, target);

        var raycast = eventData.pointerCurrentRaycast;

        Debug.Log(raycast);
        if (raycast.gameObject != null)
        {
            Debug.Log(raycast + " is not null");

            DropTarget target = eventData.pointerEnter?.GetComponent<DropTarget>();
            Debug.Log(target);

            if (target != null)
            {
                Debug.Log($"Pointer entered: {raycast.gameObject.name}");
                OnDropped?.Invoke(this, target);
            }
            else
            {
                Debug.LogWarning("No valid drop target detected!");
                ResetPosition(); // Reset to original position if no valid drop target
            }
        }
        else
        {
            Debug.LogWarning("Pointer current raycast hit nothing.");
            ResetPosition(); // Reset to original position
        }
    }

    public void ResetPosition()
    {
        rectTransform.position = originalPosition;
    }

    public void LockPosition()
    {
        this.enabled = false;
    }

}
