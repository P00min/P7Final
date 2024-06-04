using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject startScreen; // Reference to the start screen UI
    public PlayerMovement playerMovement; // Reference to the player movement script
    public GameTimer gameTimer; // Reference to the GameTimer script

    private void Start()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false; // Disable player movement at the start
        }
        else
        {
            Debug.LogError("PlayerMovement script is not assigned in the StartButton script.");
        }

        if (startScreen == null)
        {
            Debug.LogError("StartScreen UI is not assigned in the StartButton script.");
        }

        if (gameTimer == null)
        {
            Debug.LogError("GameTimer script is not assigned in the StartButton script.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        if (startScreen != null)
        {
            startScreen.SetActive(false); // Hide the start screen UI
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true; // Enable player movement
        }

        if (gameTimer != null)
        {
            gameTimer.StartTimer(); // Start the timer
        }
    }
}