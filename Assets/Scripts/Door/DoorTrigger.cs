using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorController doorController;

    private bool playerInTrigger = false;
    private bool doorOpened = false;

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.Q))
        {
           doorController.OpenDoor();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player in trigger");
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Player left trigger");

            playerInTrigger = false;
            StartCoroutine(CloseDoorWithDelay(1f));
        }
    }

    private IEnumerator CloseDoorWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        doorController.CloseDoor();
    }
}
