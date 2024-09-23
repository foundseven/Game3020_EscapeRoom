using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    public Inventory _inventory;

    public void DestroyItem()
    {
        Destroy(gameObject);
        _inventory.AddPickup();
    }
}
