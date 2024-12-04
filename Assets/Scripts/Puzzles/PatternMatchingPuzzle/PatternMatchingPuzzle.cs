using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEditor.Experimental.GraphView;

public class PatternMatchingPuzzle : MonoBehaviour
{

    #region Variables

    public List<DropTarget> dropTargets; // List of target outlines
    public List<DraggableObject> draggableObjects; // List of draggable objects

    public TextMeshProUGUI feedbackText;
    public GameObject puzzleUI; 

    public PuzzleManager puzzleManager;
    public PlayerBehaviour player; 
    public MainCamera cameraPitchRef; 
    public PuzzleTrigger puzzleTrigger;

    public float feedbackDuration = 2f;
    private int totalMatches;
    private int correctMatches = 0;


    #endregion

    void Start()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "";
        }

        totalMatches = dropTargets.Count;
        Debug.Log($" Drop Target: {dropTargets}  -  Amount: {dropTargets.Count}");
        foreach (var draggable in draggableObjects)
        {
            draggable.OnDropped += HandleObjectDropped;
        }
    }

    private void HandleObjectDropped(DraggableObject draggable, DropTarget target)
    {
        Debug.Log($"Draggable: {draggable.name}, Target: {target?.name}");

        if (target.AcceptsObject(draggable))
        {
            correctMatches++;
            feedbackText.text = "Correct match!";
            feedbackText.color = Color.green;

            draggable.LockPosition();
            CheckWinCondition();
        }
        else
        {
            feedbackText.text = "Incorrect match. Try again!";
            feedbackText.color = Color.red;
            draggable.ResetPosition();
        }
    }
    private void CheckWinCondition()
    {
        if (correctMatches == totalMatches)
        {
            HandleCorrectAnswer();
        }
    }
    private IEnumerator DisplayYouWinText()
    {
        yield return new WaitForSeconds(4.0f);

        if (puzzleUI != null)
        {
            puzzleUI.SetActive(false);
        }

        if (puzzleManager != null)
        {
            puzzleManager.CompletePuzzle();
        }
    }
    private void HandleCorrectAnswer()
    {
        feedbackText.text = "You WIN!";
        feedbackText.color = Color.green;
        puzzleManager.PlayWinSound();

        StartCoroutine(DisplayYouWinText());

        cameraPitchRef.isCameraLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleTrigger.PuzzleCompleted();
    }
}
