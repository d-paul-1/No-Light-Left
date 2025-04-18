using UnityEngine;

public class ActivateAfterDelay : MonoBehaviour
{
    public GameObject targetObject;
    public float delay = 5f;

    void Start()
    {
        // Start the coroutine that handles the delay
        StartCoroutine(ActivateObjectAfterDelay());
    }

    private System.Collections.IEnumerator ActivateObjectAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Activate the object
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
    }
}