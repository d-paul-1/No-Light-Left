using UnityEngine;

public class UIFollowHead : MonoBehaviour
{
    public Transform cameraTransform;  // Assign this to the VR camera (usually MainCamera)
    public Vector3 offset = new Vector3(0, -0.2f, 1f);  // Slightly below and in front

    void LateUpdate()
    {
        // Follow the camera's position + offset
        transform.position = cameraTransform.position + cameraTransform.forward * offset.z +
                             cameraTransform.up * offset.y + cameraTransform.right * offset.x;

        // Always face the camera
        transform.LookAt(cameraTransform);
        transform.Rotate(0, 180, 0); // Flip it to face forward
    }
}