using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera should follow.
    public Vector3 offset = new Vector3(0f, 2f, -5f); // Camera offset from the target.

    void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired camera position based on the target's position and offset.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera to the desired position using Lerp.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
    }
}