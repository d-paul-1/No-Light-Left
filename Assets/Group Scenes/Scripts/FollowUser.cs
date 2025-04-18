using UnityEngine;

public class FollowFOV : MonoBehaviour
{
    public Transform cameraTransform;  // Assign VR camera (headset)
    public float distanceInFront = 20f;
    public float heightOffset = 1f;
    public float followSpeed = 5f;

    void Update()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main?.transform;
            if (cameraTransform == null) return;
        }

        // Calculate target position in front of the user's view
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * distanceInFront;
        targetPosition.y += heightOffset;

        // Smoothly move to that position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);

        // Optionally face the user
        // Makes the button look AT the user, but corrects the facing
        Vector3 directionToCamera = transform.position - cameraTransform.position;
        transform.rotation = Quaternion.LookRotation(directionToCamera);
    }
}