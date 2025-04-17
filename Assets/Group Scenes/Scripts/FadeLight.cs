using UnityEngine;

public class FadeLight : MonoBehaviour
{
    public Light pointLight;          // Assign your Point Light here
    public float minIntensity = 0.5f; // Minimum light intensity
    public float maxIntensity = 2.0f; // Maximum light intensity
    public float fadeSpeed = 2f;      // Speed of fading
    public float flickerSpeed = 0.5f; // Speed of change direction

    private float targetIntensity;
    private float timer;

    void Start()
    {
        if (pointLight == null)
            pointLight = GetComponent<Light>();

        targetIntensity = Random.Range(minIntensity, maxIntensity);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Lerp light intensity towards the target
        pointLight.intensity = Mathf.Lerp(pointLight.intensity, targetIntensity, Time.deltaTime * fadeSpeed);

        // Every few seconds, choose a new target intensity
        if (timer >= flickerSpeed)
        {
            targetIntensity = Random.Range(minIntensity, maxIntensity);
            timer = 0f;
        }
    }
}