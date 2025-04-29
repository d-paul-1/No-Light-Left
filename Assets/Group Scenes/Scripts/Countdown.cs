using UnityEngine;
using TMPro;
using System;

public class DualCountdownTimer_TMP : MonoBehaviour
{
    public TMP_Text tenMinuteTimerText;  // TMP Text for 10-minute countdown
    public TMP_Text oneMinuteTimerText;  // TMP Text for 1-minute countdown

    private float tenMinuteTimer = 10f; // 10 minutes in seconds
    public GameObject GameOverButton;
    private float oneMinuteTimer = 60f;  // 1 minute in seconds

    private bool tenMinuteActive = true;
    private bool oneMinuteActive = true;

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
        } else{
            oneMinuteTimerText.text = "Monster is Active";
        }
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