using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Move relative to player's current facing direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        move *= speed * Time.deltaTime;

        transform.Translate(move, Space.World);
    }
}