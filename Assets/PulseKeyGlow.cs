using UnityEngine;

public class PulseKeyGlow : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float pulseSpeed = 2f;

    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
    }

    void Update()
    {
        if (lightSource != null)
        {
            lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        }
    }
}
