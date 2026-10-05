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

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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

        // Jump
        if (Input.GetKeyDown(Spacebar))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHigh);
    }
}
