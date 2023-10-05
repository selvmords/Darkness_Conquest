using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Player movement speed.

    private Rigidbody rb; // Reference to the player's Rigidbody component.
    private Transform cameraTransform; // Reference to the camera's transform.

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the player's Rigidbody component.
        cameraTransform = Camera.main.transform; // Get the main camera's transform.
    }

    void FixedUpdate()
    {
        // Input handling for player movement.
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or left/right arrow keys).
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input (W/S or up/down arrow keys).

        // Calculate the movement direction based on the camera's forward direction.
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0; // Keep the movement in the horizontal plane.
        cameraForward.Normalize();

        Vector3 movement = (cameraForward * verticalInput + cameraTransform.right * horizontalInput).normalized;

        // Apply movement to the player using Rigidbody.
        rb.velocity = movement * moveSpeed;
    }
}