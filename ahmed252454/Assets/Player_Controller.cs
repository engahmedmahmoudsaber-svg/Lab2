
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHigh = 10f;

    public KeyCode Spacebar = KeyCode.Space;
    public KeyCode L = KeyCode.L;
    public KeyCode K = KeyCode.K;

    public bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         spriteRenderer = GetComponent<SpriteRenderer>();
          anim = GetComponent<Animator>();
}

    void Update()
    {
        // Move Left
        if (Input.GetKey(L))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);

            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = true;
            }
        }

        // Move Right
        if (Input.GetKey(K))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if (spriteRenderer != null)
            {
                spriteRenderer.flipX = false;
            }
        }

        // Stop horizontal movement when no key is pressed
        if (!Input.GetKey(L) && !Input.GetKey(K))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // Jump only when touching the ground
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Check if the player is standing on the ground
        if (groundCheck != null)
        {
            grounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                whatIsGround
            );
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHigh);

        grounded = false;
    }
}
