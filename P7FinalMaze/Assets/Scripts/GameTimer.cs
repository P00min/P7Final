using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 120f; // 2 minutes in seconds
    public TMP_Text timerText; // Changed from Text to TMP_Text
    public GameObject gameOverScreen;

    private bool gameStarted = false;

    void Update()
    {
        if (gameStarted && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else if (timeRemaining <= 0 && gameStarted)
        {
            EndGame();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndGame()
    {
        // Show the game over screen
        gameOverScreen.SetActive(true);
        // Pause the game
        Time.timeScale = 0;
    }

    public void StartTimer()
    {
        gameStarted = true;
    }
}