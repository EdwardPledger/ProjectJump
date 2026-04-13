using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float JumpSpeed = 6.5f;
    private bool canJump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void Jump()
    {
        // The player can only jump once
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canJump)
        {
            rb.AddForce(Vector2.up * JumpSpeed, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    // When the player hits the platform they can jump again
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}
