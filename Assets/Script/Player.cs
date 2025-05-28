using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
