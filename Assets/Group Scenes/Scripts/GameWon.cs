using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    public GameObject objectToActivate; // The object to activate

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No object assigned to activate.");
            }
        }
    }
}