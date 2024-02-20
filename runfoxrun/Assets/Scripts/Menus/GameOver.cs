using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverUI != null)
        {
            SetGameOverUIActive(false);
        }
    }

    public void GameNowOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            SetGameOverUIActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        isGameOver = false;
        SetGameOverUIActive(false); 
        
        Health.health = 3;
    }

    public void DeactivateGameOverUI()
    {
        SetGameOverUIActive(false);
    }


    private void SetGameOverUIActive(bool isActive)
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(isActive);
        }
    }
}
