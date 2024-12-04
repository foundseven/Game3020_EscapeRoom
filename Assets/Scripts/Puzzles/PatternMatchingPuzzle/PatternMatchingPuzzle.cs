using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PatternMatchingPuzzle : MonoBehaviour
{

    #region Variables

    public List<Image> targetPatternDisplay; // UI for the target pattern
    public List<int> targetPattern; // Stores the correct sequence (e.g., shape IDs)

    private List<int> playerPattern = new List<int>(); // Player's current sequence
    public List<Button> selectableShapes; // Buttons for player to interact with

    public TextMeshProUGUI feedbackText; // Feedback for the player
    public GameObject puzzleUI; // Puzzle UI panel

    public PuzzleManager puzzleManager; // PuzzleManager reference
    public PlayerBehaviour player; // Player reference
    public MainCamera cameraPitchRef; // Camera lock reference
    public PuzzleTrigger puzzleTrigger;
    public float feedbackDuration = 2f; // How long feedback is displayed

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (feedbackText != null)
        {
            feedbackText.text = "";
        }
    }

    private void SetupTargetPattern()
    {

    }

    public void OnShapeSelected(int shapeID)
    {

    }

    public void CheckPattern()
    {

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

        StartCoroutine(DisplayYouWinText());

        cameraPitchRef.isCameraLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleTrigger.PuzzleCompleted();
    }

    private void ResetPlayerPattern()
    {
      
    }
}
