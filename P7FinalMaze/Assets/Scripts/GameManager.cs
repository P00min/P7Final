using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameStarted = false;
    public PlayerMovement playerMovement;

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        playerMovement.enabled = true; // Enable player movement
        gameObject.SetActive(false); // Disable the GameManager object
    }
}
