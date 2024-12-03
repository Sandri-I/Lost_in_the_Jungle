using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Horizontal movement speed
    public float jumpForce = 10f; // Jumping force

    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle player input
        moveInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys

        // Jump input (always allows jumping)
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Flip character sprite based on movement direction
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump()
    {
        // Apply vertical force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
