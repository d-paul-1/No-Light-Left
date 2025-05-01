using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class FlashlightAlwaysOn : MonoBehaviour
{
    private Light flashlight;
    private bool flashlightOn = true;

    private InputDevice rightHandDevice;
    public Transform monsterTransform; // Reference to the monster's Transform
    public float freezeAngleThreshold = 45f;       // Angle threshold for freezing the monster
    public float freezeDistanceThreshold = 10f;    // Max distance to freeze the monster

    private void Start()
    {
        flashlight = GetComponent<Light>();

        if (flashlight == null)
        {
            Debug.LogError("No Light component found on this GameObject.");
        }
        else
        {
            flashlight.enabled = true; // Always on at start
        }

        // Try to find the right-hand controller
        TryInitializeRightHand();
    }

    private void Update()
    {
        if (!rightHandDevice.isValid)
        {
            TryInitializeRightHand(); // Retry if device is lost
        }

        // Check for B button press to toggle the flashlight
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool isPressed) && isPressed)
        {
            ToggleFlashlight();
        }

        // Freeze monster if flashlight is pointing at it and within distance
        if (flashlightOn && IsFlashlightPointingAtMonster())
        {
            FreezeMonster(true);
        }
        else
        {
            FreezeMonster(false);
        }
    }

    private void TryInitializeRightHand()
    {
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, rightHandDevices);

        if (rightHandDevices.Count > 0)
        {
            rightHandDevice = rightHandDevices[0];
        }
    }

    private void ToggleFlashlight()
    {
        flashlightOn = !flashlightOn;
        flashlight.enabled = flashlightOn;
    }

    private bool IsFlashlightPointingAtMonster()
    {
        Vector3 flashlightDirection = transform.forward;
        Vector3 toMonster = monsterTransform.position - transform.position;

        float angle = Vector3.Angle(flashlightDirection, toMonster);
        float distance = toMonster.magnitude;

        return angle <= freezeAngleThreshold && distance <= freezeDistanceThreshold;
    }

    private void FreezeMonster(bool freeze)
    {
        MonsterBehavior monsterBehavior = monsterTransform.GetComponent<MonsterBehavior>();
        if (monsterBehavior != null)
        {
            monsterBehavior.SetFrozen(freeze);
        }
    }
}
