using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectCountingPuzzle : MonoBehaviour
{
    #region Variables

    public TMP_InputField inputField;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI feedbackText;

    public PuzzleTrigger puzzleTrigger;
    public PuzzleManager puzzleManager;
    public PlayerBehaviour player;
    public MainCamera cameraPitchRef;
    public GameObject puzzleUI;

    [SerializeField]
    public string correctAnswer = "3";

    [SerializeField]
    public string question = "How many cars can be found around the map?";

    #endregion

    void Start()
    {
        if (questionText != null)
        {
            questionText.text = question;
        }

        if (feedbackText != null)
        {
            feedbackText.text = "";
        }
    }

    public void CheckAnswer()
    {
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

    public void EscapeUI()
    {
        if (puzzleUI != null)
        {
            puzzleUI.SetActive(false);
        }
        cameraPitchRef.isCameraLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
