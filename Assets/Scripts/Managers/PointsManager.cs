using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance { get; private set; }

    public int totalPoints = 0;
    public int starsEarned {  get; private set; } = 0;


    [Header("Star Thresholds (in seconds)")]
    public float threeStarTime = 60f;
    public float twoStarTime = 120f;

    private void Awake()
    {
        if(instance != null && instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddPoints(int points)
    {
        totalPoints += points;
    }

    public void CalculateStars(float elapsedTime)
    {
        if(elapsedTime <= threeStarTime) 
        {
            starsEarned = 3;
        }
        else if (elapsedTime <= twoStarTime)
        {
            starsEarned = 2;
        }
        else
        {
            starsEarned = 1;
        }

        Debug.Log($"Stars Earned: {starsEarned}");
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }

    public void ResetPoints()
    {
        totalPoints = 0;
        starsEarned = 0;
    }
}
