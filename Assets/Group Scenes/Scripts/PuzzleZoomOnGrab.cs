using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PuzzleZoomOnGrab : MonoBehaviour
{
    public Camera zoomCamera;
    public Camera mainCamera;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab;
    private bool isHeld = false;

    void Awake()
    {
        grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        grab.selectEntered.AddListener(OnGrabbed);
        grab.selectExited.AddListener(OnReleased);

        if (zoomCamera != null) zoomCamera.enabled = false;
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        isHeld = true;
        if (zoomCamera != null) zoomCamera.enabled = true;
        if (mainCamera != null) mainCamera.enabled = false;
    }

    void OnReleased(SelectExitEventArgs args)
    {
        isHeld = false;
        if (zoomCamera != null) zoomCamera.enabled = false;
        if (mainCamera != null) mainCamera.enabled = true;
    }
}
