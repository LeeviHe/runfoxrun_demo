using UnityEngine;

public class ExitButton : MonoBehaviour
{

    // pysäyttää vain scenen unityn editorissa, pitäisi toimia jos peli on sovellus
    public void OnExitButtonClick()
    {
        Application.Quit();
        Debug.Log("Attempting to exit to windows...");
    }
}