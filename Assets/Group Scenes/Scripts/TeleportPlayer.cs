using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour
{
    public Transform playerRig;           // The XR Rig or your player GameObject
    public Transform teleportTarget;      // Where to teleport to
    public AudioSource audioSource;       // The AudioSource to disable when teleporting
    public AudioSource narration;         // Narration AudioSource
    public float audio_delay;             // Narration AudioSource (disabled by default)

    // Reference to the countdown timer and monster behavior
    public DualCountdownTimer_TMP countdownTimer;
    public MonsterBehavior monsterBehavior;  // Reference to the MonsterBehavior script

    // Reference to the Game Panel UI object
    public GameObject gamePanel;  // The Game Panel UI object to be checked

    public void Teleport()
    {
        if (playerRig != null && teleportTarget != null)
        {
            // Ensure GamePanel is checked when teleport happens
            if (gamePanel != null)
            {
                gamePanel.SetActive(true);  // Activate the GamePanel
            }

            // Start the countdown before teleporting
            if (countdownTimer != null)
            {
                countdownTimer.StartCountdown(); // Start countdown from the other script
            }

            // Start the freeze delay for the monster
            if (monsterBehavior != null)
            {
                monsterBehavior.StartFreezeDelay(); // Start freeze delay after teleporting
            }

            // Stop the background audio if it exists
            if (audioSource != null)
            {
                audioSource.Stop();
            }

            // Teleport the player
            playerRig.position = teleportTarget.position;
            playerRig.rotation = teleportTarget.rotation;

            // Start the delayed narration if assigned
            if (narration != null)
            {
                StartCoroutine(PlayNarrationAfterDelay(audio_delay));
            }
        }
        else
        {
            Debug.LogError("TeleportPlayer: PlayerRig or TeleportTarget not assigned!");
        }
    }

    private IEnumerator PlayNarrationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        narration.enabled = true;  // Enable the AudioSource
        narration.Play();          // Play the audio
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
