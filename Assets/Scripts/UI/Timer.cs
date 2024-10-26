using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//timer not done
//setting it up so it counts up, as soon as all keys 
//are collected, pause timer and display results
public class Timer : MonoBehaviour
{
    [SerializeField]
    TMP_Text _timerText;

    private float _elapsedTime = 0f;
    public bool _isTimerRunning = true;

    // Update is called once per frame
    void Update()
    {
        if(_isTimerRunning)
        {
            _elapsedTime += Time.deltaTime;

            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);

            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if(!_isTimerRunning)
        {

        }
    }

    public void StopTimer()
    {
        UnityEngine.Debug.Log("Stoping Timer");
        _isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        _isTimerRunning = true;
    }

    public float GetTime()
    {
        return _elapsedTime;
    }

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        _isTimerRunning = true;
    }

    public void StopTimerAndRewardStars()
    {
        StopTimer();
        float elapsedTiime = GetTime();

        PointsManager.instance.CalculateStars(elapsedTiime);
    }
}
