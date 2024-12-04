using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RiddlePuzzle : MonoBehaviour
{
    #region Variables

    public TMP_InputField inputField; 
    public TextMeshProUGUI riddleText; 
    public TextMeshProUGUI feedbackText; 
    
    public PuzzleTrigger puzzleTrigger;
    public PuzzleManager puzzleManager;
    public PlayerBehaviour player;
    public MainCamera cameraPitchRef;
    public GameObject puzzleUI;
    
    [SerializeField]
    public string correctAnswer = "2"; 

    [SerializeField]
    public string riddle = "I am nothing, but without me, everything would be incomplete. What am I?";

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (riddleText != null)
        {
            riddleText.text = riddle;
        }

        if (feedbackText != null)
        {
            feedbackText.text = "";
        }
    }

    public void CheckAnswer()
    {
        puzzleManager.PlayClickSound();
        if (inputField.text == correctAnswer)
        {
            HandleCorrectAnswer();
        }
        else
        {
            HandleIncorrectAnswer();
        }
    }

    private void HandleCorrectAnswer()
    {
        feedbackText.text = "The correct number is " + correctAnswer;
        feedbackText.color = Color.green;
        puzzleManager.PlayWinSound();

        StartCoroutine(DisplayYouWinText());

        cameraPitchRef.isCameraLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleTrigger.PuzzleCompleted();
        inputField.interactable = false;
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

    private void HandleIncorrectAnswer()
    {
        feedbackText.text = "Incorrect answer. Try again!";
        feedbackText.color = Color.red;
    }
}
