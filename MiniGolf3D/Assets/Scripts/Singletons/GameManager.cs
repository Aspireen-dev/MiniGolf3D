using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton pattern
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        // Limit framerate to 60 (for pcs/smartphones that can show more than 60 images per seconds)
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
    }

    private int totalScore = 0;

    public int GetScore()
    {
        return totalScore;
    }

    public void IncreaseScore(int score)
    {
        totalScore += score;
    }
}
