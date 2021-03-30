using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLevelPanel : MonoBehaviour
{
    public Text totalScoreText;
    public GameObject pauseBtn;

    private int nextLevel;

    private void Start()
    {
        pauseBtn.SetActive(false);
        SetScoreText();

        nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        UnlockNextLevel();
    }

    private void SetScoreText()
    {
        totalScoreText.text = "Total score : " + GameManager.Instance.GetScore();
    }

    private void UnlockNextLevel()
    {
        // Get last unlocked level from PlayerPrefs and update it
        int lastUnlockedLevel = PlayerPrefs.GetInt("lastUnlockedLevel");
        if (nextLevel > lastUnlockedLevel)
        {
            PlayerPrefs.SetInt("lastUnlockedLevel", nextLevel);
        }
    }

    // ----- Buttons -----
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
