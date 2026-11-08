using UnityEngine;

// Controls the camera movement to smoothly follow a target object.
public class CameraFollow : MonoBehaviour
{
    // Reference to the target object the camera will follow.
    public Transform target;

    // Controls how smoothly the camera moves towards the target position.
    public float smoothSpeed = 5f;

    // Horizontal offset applied to the camera's target position.
    public float offsetX = 0f;

    // Used to update the camera position smoothly.
    void LateUpdate()
    {
        // Stop camera movement if no target has been assigned.
        if (target == null) return;

        // Calculates the desired camera position based on the target's horizontal position while preserving the camera's current vertical position and depth.
        Vector3 desiredPosition = new Vector3(
            target.position.x + offsetX,
            transform.position.y,
            transform.position.z);

        // Smoothly interpolates between the current camera position and the desired position
            transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime);
    }
}
