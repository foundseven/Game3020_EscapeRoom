using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{

    #region Variables

    public PlayerBehaviour player;
    public MainCamera cameraPitchRef;
    public GameObject interactionPrompt;
    public GameObject puzzleUI;
    private bool isPlayerInRange = false;


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (interactionPrompt != null)
        {
           interactionPrompt.SetActive(false);
        }

        if (puzzleUI != null)
        {
           puzzleUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            ActivatePuzzle();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (interactionPrompt != null)
            {
               interactionPrompt.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if (interactionPrompt != null)
            {
               interactionPrompt.SetActive(false);
            }
        }
    }

    private void ActivatePuzzle()
    {
        Debug.Log("Pushed E to interact.. moving to puzzle..");
        
        if (puzzleUI != null)
        {
            puzzleUI.SetActive(true);
        }

        if (interactionPrompt != null)
        {
            interactionPrompt.SetActive(false);
        }

        //todo - disable player controls here
        cameraPitchRef.isCameraLocked = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //lock cross hairs too
    }


}
