using UnityEngine;

// Controls the camera movement to smoothly follow a target object.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;
    public float offsetX = 0f;
    public float minX;
    public float maxX;

    // Used to update the camera position smoothly.
    void LateUpdate()
    {
        // Stop camera movement if no target has been assigned.
        if (target == null) return;

        // Calculate the target X position with the horizontal offset.
        float targetX = target.position.x + offsetX;
        // Keep the camera within the defined horizontal limits.
        targetX = Mathf.Clamp(
            targetX,
            minX,
            maxX);
        Debug.Log(targetX);

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
