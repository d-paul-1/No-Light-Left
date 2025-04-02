using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour
{
    public Light myLight; // Assign the light object in the inspector
    public float minIntensity = 0.5f; // Minimum intensity
    public float maxIntensity = 1.0f; // Maximum intensity
    public float flickerSpeed = 1.0f; // How fast the light flickers

    void Start()
    {
        if (myLight == null)
        {
            myLight = GetComponent<Light>(); // If not assigned, get the light component
        }
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float targetIntensity = Random.Range(minIntensity, maxIntensity);
            float duration = Random.Range(0.1f, 0.5f); // Random duration for each flicker
            float t = 0.0f;

            while (t < duration)
            {
                myLight.intensity = Mathf.Lerp(myLight.intensity, targetIntensity, t / duration);
                t += Time.deltaTime * flickerSpeed;
                yield return null;
            }
        }
    }
}