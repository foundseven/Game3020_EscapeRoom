using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequencePuzzle : MonoBehaviour
{
    #region Variables
    public List<int> correctSequence;
    private List<int> playerSequence = new List<int>();
    public List<Button> buttons;

    public PlayerBehaviour player;
    public MainCamera cameraPitchRef;

    public GameObject successMessage;
    public GameObject puzzleUI;

    public float displayDelay = 1.0f;
    private bool isDisplayingSequence = false;

    public PuzzleManager puzzleManager;
    public PuzzleTrigger puzzleTrigger;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (successMessage != null)
        {
            successMessage.SetActive(false);
        }
    }

    public void StartPuzzle()
    {
        playerSequence.Clear();
        StartCoroutine(DisplaySequence());
    }

    private IEnumerator DisplaySequence()
    {
        isDisplayingSequence = true;

        // Highlight each button in the correct sequence
        foreach (int buttonID in correctSequence)
        {
            HighlightButton(buttonID);
            yield return new WaitForSeconds(displayDelay);
            ResetButtonAppearance(buttonID);
        }

        isDisplayingSequence = false;
    }


    public void OnButtonPressed(int buttonID)
    {

        if (isDisplayingSequence) return;

        Debug.Log($"Button {buttonID} pressed!");
        playerSequence.Add(buttonID);
        CheckSequence();
    }

    private void CheckSequence()
    {
        for (int i = 0; i < playerSequence.Count; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                ResetPuzzle();
                return;
            }
        }

        if (playerSequence.Count == correctSequence.Count)
        {
            PuzzleComplete();
        }
    }

    private void HighlightButton(int buttonID)
    {
        // Example: Change button color to indicate it's highlighted
        buttons[buttonID - 1].GetComponent<Image>().color = Color.yellow;
    }

    private void ResetButtonAppearance(int buttonID)
    {
        // Reset button color to default
        buttons[buttonID - 1].GetComponent<Image>().color = Color.white;
    }

    private void ResetPuzzle()
    {
        Debug.Log("Incorrect sequence. Resetting puzzle...");
        playerSequence.Clear();
    }

    private void PuzzleComplete()
    {
        Debug.Log("Puzzle complete!");

        StartCoroutine(DisplayYouWinText());

        cameraPitchRef.isCameraLocked = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        puzzleTrigger.PuzzleCompleted();

    }

    private IEnumerator DisplayYouWinText()
    {
        if (successMessage != null)
        {
            successMessage.SetActive(true);
        }

        yield return new WaitForSeconds(5.0f);

        if (puzzleUI != null)
        {
            puzzleUI.SetActive(false);
        }

        if (puzzleManager != null)
        {
            puzzleManager.CompletePuzzle();
        }
    }
}
