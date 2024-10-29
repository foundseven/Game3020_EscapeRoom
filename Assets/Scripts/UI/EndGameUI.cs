using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGameUI : MonoBehaviour
{
    [SerializeField]
    GameObject _endGamePanel;

    [SerializeField]
    TMP_Text _elapsedText;

    [SerializeField]
    TMP_Text _starsText;

    [SerializeField]
    TMP_Text _highScoreText;

    [SerializeField]
    Button _continueButton;

    public PlayerBehaviour player;

    public MainCamera cameraPitchRef;

    // Start is called before the first frame update
    void Start()
    {
        _endGamePanel.SetActive(false);

        //adding a listening for the continue button
        _continueButton.onClick.AddListener(ResumeGame);
    }

    public void ShowEndGameUI(float elapsedTime, int stars)
    {
        // Lock player input
        player.isInputLocked = true;
        cameraPitchRef.isCameraLocked = true;

        // Show the panel
        _endGamePanel.SetActive(true);

        Debug.Log("Showing UI");

        //time
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        _elapsedText.text = $"Time: {minutes:00}:{seconds:00}";

        //display the stars
        _starsText.text = $"Stars Earned: {stars}";

        LevelManager.Instance.SetHighScore(SceneManager.GetActiveScene().name, elapsedTime);

        //display the highscore
        if(LevelManager.Instance.GetHighScore(SceneManager.GetActiveScene().name) < elapsedTime)
        {
            _highScoreText.text = $"HighScore: {LevelManager.Instance.GetHighScore(SceneManager.GetActiveScene().name)}";
        }
        else /*if(elapsedTime < LevelManager.Instance.GetHighScore(SceneManager.GetActiveScene().name))*/
        {
            _highScoreText.text = $"New HighScore: {LevelManager.Instance.GetHighScore(SceneManager.GetActiveScene().name)}";
        }

        Debug.Log("Highscore: " + LevelManager.Instance.GetHighScore(SceneManager.GetActiveScene().name));
        //pause
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Show the panel
        _endGamePanel.SetActive(true);
    }

    private void ResumeGame()
    {
        // Unlock player input
        player.isInputLocked = false;
        cameraPitchRef.isCameraLocked = false;


        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        _endGamePanel.SetActive(false);

        Debug.Log("Game Resumed. Player can now leave the map.");
    }
}
