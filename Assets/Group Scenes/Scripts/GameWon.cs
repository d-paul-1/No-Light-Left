using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public GameObject GameWonButton; // The object to activate
    public GameObject Monster;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameWonButton != null && Monster != null)
            {
                GameWonButton.SetActive(true);
                Monster.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No object assigned to activate.");
            }
        }
    }
}