using UnityEngine;

public class CapsuleFollowPlayer : MonoBehaviour
{
    public Transform xrRig;  // Reference to your XR Rig
    private Vector3 offset;   // To store any relative offset

    void Start()
    {
        if (xrRig != null)
        {
            // Store the initial offset between the capsule and the XR Rig
            offset = transform.position - xrRig.position;
        }
    }

    void Update()
    {
        if (xrRig != null)
        {
            // Move the capsule to follow the XR Rig's position with the offset
            transform.position = xrRig.position + offset;
        }
    }
}
