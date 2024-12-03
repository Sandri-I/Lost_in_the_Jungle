using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector2 offset; // Offset between the camera and the player
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    public Vector2 minBounds; // Minimum boundaries for camera movement
    public Vector2 maxBounds; // Maximum boundaries for camera movement

    void LateUpdate()
    {
        // Calculate the target position with offset
        Vector3 targetPosition = new Vector3(
            player.position.x + offset.x,
            player.position.y + offset.y,
            transform.position.z // Keep the camera's Z position fixed
        );

        // Smoothly interpolate the camera's position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Clamp the camera's position to stay within the bounds
        float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

        // Apply the clamped position
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}

