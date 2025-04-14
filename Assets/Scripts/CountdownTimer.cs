using UnityEngine;
using TMPro; // Use UnityEngine.UI if you're not using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60f; // 60 seconds
    public TextMeshProUGUI countdownText; // Link this in the Inspector
    private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
                TimerEnded();
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay += 1; // Optional: rounds up so 0.9 becomes 1 instead of 0

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Timer ended!");
        // Do whatever you want when the timer hits 0
    }
}
