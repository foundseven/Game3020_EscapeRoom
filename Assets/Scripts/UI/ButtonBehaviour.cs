using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonBehaviour : MonoBehaviour
{
   public void LoadGame()
   {
        SceneManager.LoadScene("MainMap");
   }

    public void HowToPlay()
    {
        SceneManager.LoadScene("InstructionMap");
    }

    public void BackToMM()
    {
        SceneManager.LoadScene("MainMenu");

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
