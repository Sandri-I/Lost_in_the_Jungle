using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    private Transform player; // Reference to the player's Transform
    public Vector2 offset; // Offset between the camera and the player
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    private void Start()
    {
        // Automatically find the player object with the "Player" tag
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("Player found: " + player.name);
        }
        else
        {
            Debug.LogError("Player object with tag 'Player' not found!");
        }
    }

    private void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is still not assigned!");
            return;
        }

        // Follow the player's position
        Vector3 targetPosition = new Vector3(
            player.position.x + offset.x,
            player.position.y + offset.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    }
}


