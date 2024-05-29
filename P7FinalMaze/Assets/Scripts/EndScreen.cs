using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public GameObject endScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowEndScreen();
        }
    }

    void ShowEndScreen()
    {
        endScreen.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }
}