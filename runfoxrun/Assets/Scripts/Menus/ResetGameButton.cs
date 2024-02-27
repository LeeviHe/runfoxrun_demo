using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour
{
    public GameOver gameOver;
    public Completed completed;

    public void OnTryAgainButtonClick()
    {
        if (gameOver != null)
        {
            gameOver.DeactivateGameOverUI(); 
            gameOver.RestartGame(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (completed != null) {
            completed.DeactivateCompletedUI();
            completed.RestartGame();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
