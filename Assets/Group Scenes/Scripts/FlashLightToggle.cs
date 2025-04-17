using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    private Light flashlight;

    void Start()
    {
        flashlight = GetComponent<Light>();

        if (flashlight == null)
        {
            Debug.LogError("No Light component found on this GameObject.");
        }
        else
        {
            flashlight.enabled = false; // start OFF
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}

