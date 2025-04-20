using UnityEngine;
using TMPro;

public class GameEnds : MonoBehaviour
{
    public float totalTime = 600f; // 10 minutes
    private float timeLeft;

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


        if (timeLeft <= 0f && !gameEnded)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverPanel.SetActive(true);
    }
}