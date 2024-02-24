using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameOver gameOver;
    public void LoadGame()
    {
        SceneManager.LoadScene("MappiNurkkaus");
    }

      public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
