using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Horizontal movement speed
    [SerializeField] private float jumpForce = 10f; // Jumping force

    private Rigidbody2D rb;
    private float moveInput; // Horizontal input value
    private bool facingRight = true; // Tracks the direction the player is facing

    private void Awake()
    {
        // Get Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing!");
        }
    }

    private void Update()
    {
        // Handle horizontal movement input
        moveInput = Input.GetAxis("Horizontal");

        // Allow jumping every time space is pressed
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // Flip the player's sprite based on movement direction
        FlipSprite();
    }

    private void FixedUpdate()
    {
        // Apply horizontal movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        // Apply jump force
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        Debug.Log("Jump executed!");
    }

    private void FlipSprite()
    {
        // Flip the player only if the movement direction changes
        if ((moveInput > 0 && !facingRight) || (moveInput < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}
