using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    public Text completedTimerText;

    private float secondsCount;
    private int minuteCount;

    void Update() {
        UpdateTimerUI();
    }

    // Call this on update
    public void UpdateTimerUI() {
        // Set timer UI
        
        if (Health.health == 0 || playerMovement.chestCollected == true) {
            //Stop counter
            completedTimerText.text = minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00");
        } else { 
           secondsCount += Time.deltaTime;
            timerText.text = minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00");
            if (secondsCount >= 60) {
                secondsCount = 0;
                minuteCount++;
            } 
        }
    }
}