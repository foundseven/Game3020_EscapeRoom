using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private bool isItemOverlapping = false;

    private void Update()
    {
        if (isItemOverlapping && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with Pickup Item");
            Inventory.Instance.AddPickup();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") )
        {
            isItemOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isItemOverlapping = false;
        }
    }
}
