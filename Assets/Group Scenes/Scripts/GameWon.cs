using UnityEngine;
using System.Collections;

public class TriggerActivator : MonoBehaviour
{
    public GameObject GameWonButton;
    public GameObject Monster;
    public AudioSource victoryAudio;
    public float audioDelay = 1f; // Delay before playing the audio

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone.");

            if (GameWonButton != null && Monster != null)
            {
                GameWonButton.SetActive(true);
                Debug.Log("GameWonButton activated.");

                Monster.SetActive(false);
                Debug.Log("Monster deactivated.");

                if (victoryAudio != null)
                {
                    StartCoroutine(PlayVictoryAudioAfterDelay(audioDelay));
                }
                else
                {
                    Debug.LogWarning("Victory audio is not assigned.");
                }
            }
            else
            {
                Debug.LogWarning("GameWonButton or Monster not assigned.");
            }
        }
    }

    private IEnumerator PlayVictoryAudioAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        victoryAudio.enabled = true;  // Enable the AudioSource
        victoryAudio.Play();          // Play the audio
        Debug.Log("Victory audio played.");
    }
}
