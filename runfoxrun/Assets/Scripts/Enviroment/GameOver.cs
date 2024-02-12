using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Reference to the Health script
    public Health playerHealth;
    public GameObject gameOverUI;

    
    private void Start()
    {
        // Ensure the game over UI is initially deactivated
        gameOverUI.SetActive(false);
    }

    private void Update()
    {
        // Check if player's health is zero
        if (Health.health <= 0)
        {
            // If health is zero, trigger game over
            GameOver();
        }
    }

  private void GameOver()
    {
        // Activate the game over UI
        gameOverUI.SetActive(true);

        // Pause the game (optional)
        Time.timeScale = 0f;
    }
}