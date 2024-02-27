using UnityEngine;

public class Completed : MonoBehaviour {
    public GameObject completedUI;
    private static bool isCompleted = false;

    void Start()
    {
        if (completedUI != null)
        {
            Debug.Log("testti");
            SetCompletedUIActive(false);
        }
    }

    public void GameCompleted()
    {
        Debug.Log(isCompleted);
        if (!isCompleted)
        {
            Debug.Log("iscompleted = true");
            isCompleted = true;
            SetCompletedUIActive(true);
        }
    }

    public void RestartGame()
    {
        isCompleted = false;
        SetCompletedUIActive(false); 
        
        Health.health = 3;
    }

    public void DeactivateCompletedUI()
    {
        SetCompletedUIActive(false);
    }


    private void SetCompletedUIActive(bool isActive)
    {
        Debug.Log(completedUI);
        if (completedUI != null)
        {
            Debug.Log(isActive + "setti");
            completedUI.SetActive(isActive);
        }
    }
}
