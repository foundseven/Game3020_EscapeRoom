using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//i want to add the pickup items into an array
//than that way it will count how many pickups are in each level and count down accordingly

public class Inventory : MonoBehaviour
{
    //[SerializeField] TMP_Text _pickupCountCountText;

    public static Inventory Instance;
    public int _pickupCount = 0;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPickup()
    {
        _pickupCount++;
        Debug.Log("Added Pickup to inv.");
        Debug.Log("Pickups in inv: " + _pickupCount);
        // _pickupCountCountText.text = "Pickup Items: " + _pickupCount;
        CheckPickup();

    }

    public void CheckPickup()
    {
        //this is a random value now
        if(_pickupCount >= 1)
        {
            Debug.Log("All Keys Acquired!");
        }
    }

    public void RestartPickup()
    {
        _pickupCount = 0;
       // _pickupCountCountText.text = "Pickup Items: " + _pickupCount;

    }
}
