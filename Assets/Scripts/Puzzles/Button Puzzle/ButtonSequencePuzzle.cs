using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSequencePuzzle : MonoBehaviour
{
    #region Variables
    public List<int> correctSequence;
    private List<int> playerSequence = new List<int>();

    public GameObject successMessage;
    public GameObject puzzleUI;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        if (successMessage != null)
        {
            successMessage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPressed()
    {

    }

    private void CheckSequence()
    {

    }

    private void ResetPuzzle()
    {

    }

    private void PuzzleComplete()
    {

    }
}
