using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //tweak this so i can click it
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("Pickup Item Found");
                Inventory.Instance.AddPickup();
                Destroy(gameObject);
            }
        }
    }
}
