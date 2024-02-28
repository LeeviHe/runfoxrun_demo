using UnityEngine;

public class QuitGameButton : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit game pressed");
    }
}
