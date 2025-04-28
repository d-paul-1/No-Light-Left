using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform playerRig;           // The XR Rig or your player GameObject
    public Transform teleportTarget;      // Where to teleport to
    public AudioSource audioSource;       // The AudioSource to disable when teleporting

    public void Teleport()
    {
        if (playerRig != null && teleportTarget != null)
        {
            // Turn off the AudioSource if it exists
            if (audioSource != null)
            {
                audioSource.Stop(); // Stops the audio from playing
            }

            // Teleport the player
            playerRig.position = teleportTarget.position;
            playerRig.rotation = teleportTarget.rotation;
        }
        else
        {
            Debug.LogError("TeleportPlayer: PlayerRig or TeleportTarget not assigned!");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
}
