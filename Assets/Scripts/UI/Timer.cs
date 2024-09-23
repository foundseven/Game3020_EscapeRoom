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
        _elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        _isTimerRunning = false;
    }

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        _isTimerRunning = true;
    }
}
