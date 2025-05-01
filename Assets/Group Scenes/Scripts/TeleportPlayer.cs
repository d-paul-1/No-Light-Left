using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour
{
    public Transform playerRig;           // The XR Rig or your player GameObject
    public Transform teleportTarget;      // Where to teleport to
    public AudioSource audioSource;       // The AudioSource to disable when teleporting
    public AudioSource narration;    
    public float audio_delay;    // Narration AudioSource (disabled by default)

    public void Teleport()
    {
        if (playerRig != null && teleportTarget != null)
        {
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
