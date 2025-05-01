using UnityEngine;

public class PulsingLight : MonoBehaviour
{
    public float pulseSpeed = 5f;  // Speed of pulsing
    public float maxIntensity = 8f; // Brightest point
    public float minIntensity = 0f; // Dimmest point

    private Light _light;
    private bool _increasing = true;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if (_increasing)
        {
            _light.intensity += pulseSpeed * Time.deltaTime;
            if (_light.intensity >= maxIntensity)
                _increasing = false;
        }
        else
        {
            _light.intensity -= pulseSpeed * Time.deltaTime;
            if (_light.intensity <= minIntensity)
                _increasing = true;
        }
    }
}
