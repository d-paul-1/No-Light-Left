using UnityEngine;
using TMPro;
using System;

public class DualCountdownTimer_TMP : MonoBehaviour
{
    public TMP_Text tenMinuteTimerText;  // TMP Text for 10-minute countdown
    public TMP_Text oneMinuteTimerText;  // TMP Text for 1-minute countdown

    public float tenMinuteTimer = 600f; // 10 minutes in seconds (600 seconds)
    public GameObject GameOverButton;
    public float oneMinuteTimer = 60f;  // 1 minute in seconds

    private bool tenMinuteActive = false;
    private bool oneMinuteActive = false;

    void Update()
    {
        // 10-minute timer
        if (tenMinuteActive && tenMinuteTimer > 0f)
        {
            tenMinuteTimer -= Time.deltaTime;
            if (tenMinuteTimer <= 0f)
            {
                tenMinuteTimer = 0f;
                tenMinuteActive = false;
                GameOverButton.SetActive(true);
            }
            UpdateTimerText(tenMinuteTimerText, tenMinuteTimer);
        }

        // 1-minute timer
        if (oneMinuteActive && oneMinuteTimer > 0f)
        {
            oneMinuteTimer -= Time.deltaTime;
            if (oneMinuteTimer <= 0f)
            {
                oneMinuteTimer = 0f;
                oneMinuteActive = false;
            }
            UpdateTimerText(oneMinuteTimerText, oneMinuteTimer);
        } 
        else
        {
            oneMinuteTimerText.text = "Monster is Active";
        }
    }

    // Method to start the countdowns when teleport happens
    public void StartCountdown()
    {
        tenMinuteActive = true;
        oneMinuteActive = true;
        GameOverButton.SetActive(false);  // Hide the game over button at the start
        Debug.Log("Countdown started!");
    }

    void UpdateTimerText(TMP_Text textComponent, float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);
        string formattedTime = string.Format("{0:D2}:{1:D2}", time.Minutes, time.Seconds);

        if (textComponent != null)
        {
            textComponent.text = formattedTime;
        }
    }
}
