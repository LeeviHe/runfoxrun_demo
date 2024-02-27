using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameOver gameOver;
    public void LoadGame()
    {
        SceneManager.LoadScene("MappiNurkkaus");
        FindObjectOfType<SoundEffects>().LevelMusic();
        Debug.Log("Pelimusiikki soi");
    }

      public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        FindObjectOfType<SoundEffects>().MainMenuMusic();
        Debug.Log("Main menu musiikki soi");
    }
}
