using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    //so this would be for an actual button
    [SerializeField] private GameObject _loaderCanvas;

    //for a loading progress bar
    [SerializeField] private Image _progressBar;

    //defining my keys
    private const string CompletedLevelKey = "CompletedLevel_";
    private const string HighScoreKey = "HighScore";

    void Awake()
    {
       if(Instance == null)
       {
            Instance = this;
            DontDestroyOnLoad(gameObject);
       }
       else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        //set the loader canvas to true
         _loaderCanvas.SetActive(true);

         //see how much the scene has loaded and change the fill amount
         do
         {
                //basically this updates every .1 seconds and fills the porgress bar
             await Task.Delay(1000);
             _progressBar.fillAmount = scene.progress;
         }
         while (scene.progress < 0.9f);

         scene.allowSceneActivation = true;
         //disable the loader canvas
         _loaderCanvas.SetActive(true);
    }

    //player prefs save small bits of data
    public void MarkLevelComplete(string levelName)
    {
        PlayerPrefs.SetInt(CompletedLevelKey + levelName, 1);
        PlayerPrefs.Save();
    }

    public bool IsLevelComplete(string levelName)
    {
        return PlayerPrefs.GetInt(CompletedLevelKey + levelName, 0) == 1;
    }

    public void SetHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }
}
