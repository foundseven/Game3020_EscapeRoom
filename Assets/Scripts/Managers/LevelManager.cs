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
    private const string HighScoreKey = "HighScore_";

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

    public void SetHighScore(string levelName, float time)
    {
        if(time < GetHighScore(levelName))
        {
            PlayerPrefs.SetFloat(HighScoreKey + levelName, time);
            PlayerPrefs.Save();
        }
    }

    public float GetHighScore(string levelName)
    {
        return PlayerPrefs.GetFloat(HighScoreKey + levelName, float.MaxValue); // Return max value if no score
    }

    public void ResetHighScores(string levelName)
    {
        string key = "HighScore_" + levelName;

        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
            Debug.Log($"High score reset for {levelName}");
        }

        PlayerPrefs.Save();
    }
    public void ResetCompletedLevels(string levelName)
    {
        string key = CompletedLevelKey + levelName;

        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
            Debug.Log($"Completed level reset for {levelName}");
        }

        PlayerPrefs.Save();
    }

    [ContextMenu("Reset High Scores")]
    public void ResetHighScoresFromEditor()
    {
        ResetHighScores(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Reset Completed Levels")]
    public void ResetCompletedLevelsFromEditor()
    {
        ResetCompletedLevels(SceneManager.GetActiveScene().name);
    }

}
