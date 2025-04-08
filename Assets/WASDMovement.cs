using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WASDMovement : MonoBehaviour
{
    public Transform cameraTransform;     // Assign your XR Main Camera here
    public float moveSpeed = 2f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get WASD input
        float horizontal = Input.GetAxis("Horizontal"); // A/D
        float vertical = Input.GetAxis("Vertical");     // W/S

        // Get forward direction relative to camera
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Flatten the movement (ignore Y axis)
        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * vertical + right * horizontal;

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
