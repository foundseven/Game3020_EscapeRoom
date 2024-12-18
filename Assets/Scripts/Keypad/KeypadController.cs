using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadController : MonoBehaviour
{
    public DoorController door;

    [SerializeField]
    public EndGameUI endGameUI;

    public Timer timer;
    public string _password;
    public int _passwordLimit;
    public Text _passwordText;

    public string currentLevelName;

    //audio
    [SerializeField]
    AudioClip _clickSound;

    private void Start()
    {
        _passwordText.text = "";
    }

    public void PasswordEntry(string number)
    {
        if (number == "Clear")
        {
            Clear();
            return;
        }
        else if (number == "Enter")
        {
            Enter();
            return;
        }

        int length = _passwordText.text.ToString().Length;
        if (length < _passwordLimit)
        {
            _passwordText.text = _passwordText.text + number;
        }
    }
    private void Clear()
    {
        _passwordText.text = "";
        _passwordText.color = Color.white;
    }

    private void Enter()
    {
        //so if it is right change color and open
        if (_passwordText.text == _password)
        {
            SoundManager.instance.PlayAudioClip(_clickSound);
            door.lockedByPassword = false;

            _passwordText.color = Color.green;
            timer.StopTimerAndRewardStars();

            float elapsedTime = timer.GetTime();
            int stars = PointsManager.instance.starsEarned;

            endGameUI.ShowEndGameUI(elapsedTime, stars);
            Debug.Log("Showing UI");

            LevelManager.Instance.MarkLevelComplete(currentLevelName);
            Debug.Log("Level " +  currentLevelName + "is completed");
            StartCoroutine(waitAndClear());
        }
        //if it is wrong change color dont open
        else
        {
            _passwordText.color = Color.red;
            StartCoroutine(waitAndClear());
        }
    }

    IEnumerator waitAndClear()
    {
        yield return new WaitForSeconds(0.75f);
        Clear();
    }
}
