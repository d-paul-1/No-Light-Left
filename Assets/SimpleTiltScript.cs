using UnityEngine;


public class SimpleTiltOnGrab : MonoBehaviour
{
    // Use negative X and positive Z for \ slope
    public Vector3 tiltAmount = new Vector3(-25f, 0f, 10f);

    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;

        UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grab = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grab != null)
        {
            grab.selectEntered.AddListener((args) => TiltBoard());
            grab.selectExited.AddListener((args) => ResetBoard());
        }
    }

    void TiltBoard()
    {
        transform.rotation = Quaternion.Euler(originalRotation.eulerAngles + tiltAmount);
    }

    void ResetBoard()
    {
        transform.rotation = originalRotation;
    }
}
