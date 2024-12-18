using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PuzzleManager : MonoBehaviour
{

    #region Variables
    [SerializeField]
    public string levelCode = "0000";
    public TMP_Text codeDisplay;
    public TMP_Text completedLevelText;
    private int clueIndex = 0;

    [SerializeField]
    AudioClip _clickSound, _winSound;

    #endregion

    private void Start()
    {
        codeDisplay.text = "";
        completedLevelText.text = "You need to find the code!";
    }
    public void RevealClue(int number)
    {
        if (clueIndex < levelCode.Length)
        {
            codeDisplay.text += levelCode[clueIndex]; 
            clueIndex++;

            if (clueIndex == levelCode.Length)
            {
                ShowCodeInputMessage();
            }
        }
    }

    public void PlayClickSound()
    {
        SoundManager.instance.PlayAudioClip(_clickSound);
    }

    public void PlayWinSound()
    {
        SoundManager.instance.PlayAudioClip(_winSound);
    }

    public void CompletePuzzle()
    {
        RevealClue(0);  // Reveals the first number of the level code
    }

    private void ShowCodeInputMessage()
    {
        if (completedLevelText != null)
        {
            completedLevelText.text = "All code numbers revealed! Go input the code into the code box.";
        }
    }
}
