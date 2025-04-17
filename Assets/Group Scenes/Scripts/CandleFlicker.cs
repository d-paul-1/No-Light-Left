using UnityEngine;

[RequireComponent(typeof(Light))]
public class CandleFlicker : MonoBehaviour
{
    [Header("Flicker Settings")]
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.2f;
    public float flickerSpeed = 2.5f; // Speed of intensity change

    [Header("Position Jitter Settings")]
    public bool enablePositionJitter = true;
    public float positionJitterAmount = 0.02f;
    public float positionJitterSpeed = 1.5f;

    private Light candleLight;
    private float baseIntensity;
    private Vector3 initialPosition;
    private float flickerTime;
    private float jitterTime;

    void Start()
    {
        candleLight = GetComponent<Light>();
        baseIntensity = candleLight.intensity;
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        // Flicker light intensity with smooth Perlin noise
        flickerTime += Time.deltaTime * flickerSpeed;
        float noise = Mathf.PerlinNoise(flickerTime, 0.0f);
        candleLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise) * baseIntensity;

        // Slightly jitter the light position for added realism
        if (enablePositionJitter)
        {
            jitterTime += Time.deltaTime * positionJitterSpeed;
            float offsetX = (Mathf.PerlinNoise(jitterTime, 0.0f) - 0.5f) * 2f * positionJitterAmount;
            float offsetY = (Mathf.PerlinNoise(0.0f, jitterTime) - 0.5f) * 2f * positionJitterAmount;
            transform.localPosition = initialPosition + new Vector3(offsetX, offsetY, 0);
        }
    }
}