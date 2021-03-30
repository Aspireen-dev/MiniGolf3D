using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused;
    public GameObject pausePanel;

    private void Start()
    {
        isPaused = false;
    }

    // Retour au menu
    private void OnDisable()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void SetPauseState()
    {
        // Si on n'est pas en pause, on met en pause
        if (!isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        // Sinon on enlève la pause
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        isPaused = !isPaused;
    }
}
