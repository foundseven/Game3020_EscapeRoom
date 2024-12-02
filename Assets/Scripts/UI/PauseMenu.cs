using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public PlayerBehaviour player;

    public MainCamera cameraPitchRef;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    public void TogglePauseMenu()
    {
        if (gameObject.activeSelf)
        {
            Debug.Log("Not Showing Pause Screen");
            // Unlock player input
            cameraPitchRef.isCameraLocked = false;
            gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;

        }
        else
        {
            Debug.Log("Showing Pause Screen");
            // Lock player input
            cameraPitchRef.isCameraLocked = true;

            gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnMainMenuPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
