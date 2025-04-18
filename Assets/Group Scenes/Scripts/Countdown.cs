using UnityEngine;
using TMPro;

public class CountdownTimerTMP : MonoBehaviour
{
    public float totalTime = 600f; // 10 minutes
    private float timeLeft;

    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    private bool gameEnded = false;

    void Start()
    {
        timeLeft = totalTime;
        gameOverPanel.SetActive(false); // Hide Game Over at start
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(timeLeft, 0f);

        UpdateTimerDisplay();

        if (timeLeft <= 0f && !gameEnded)
        {
            EndGame();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
    }
}