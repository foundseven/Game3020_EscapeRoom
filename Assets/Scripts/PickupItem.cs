using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    //[SerializeField]
    //public Inventory _inventory;

    //public void DestroyItem()
    //{
    //    Destroy(gameObject);
    //    _inventory.AddPickup();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || Input.GetKey(KeyCode.E))
        {
            Debug.Log("Interacted with Pickup Item");
            Inventory.Instance.AddPickup();
            Destroy(gameObject);
        }
    }
}
