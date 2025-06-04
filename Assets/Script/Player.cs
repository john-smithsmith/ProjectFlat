using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float climbSpeed = 3f;

    private Rigidbody2D rb;
    private float originalGravity;
    private Animator animator;

    private float horizontalInput;
    private float verticalInput;
    private bool jumpInputDown;

    private bool isGrounded = false;
    private bool isPaused = false;
    private bool isClimbing = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalGravity = rb.gravityScale;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical"); 

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInputDown = true;
        }

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        animator.SetBool("ismove", Mathf.Abs(horizontalInput) > 0.01f);

        bool currentlyOnAir = !isGrounded && !isClimbing;
        animator.SetBool("onair", currentlyOnAir);

    }

    void FixedUpdate() 
    {
        
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        
        if (jumpInputDown && isGrounded && !isClimbing)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            animator.SetBool("isjump", true);
        }
        jumpInputDown = false;

       
        if (isClimbing)
        {
            
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);
        }
        else
        {
           
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded) 
            {
                isGrounded = true;
                animator.SetBool("isjump", false); 
                animator.SetTrigger("land");      
            }
        }
    }

    
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            Debug.Log("Enter Trigger: " + other.gameObject.name);
            isClimbing = true;
            rb.gravityScale = 0f;
            
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = originalGravity;
            
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        
    }
}
