using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joyStick;  // touch control
    public Animator animator;   // animation
    public int speed = 5;   // horizontal speed
    public int jump = 7;  // vetical speed

    private Rigidbody2D rb;

    // jumping
    bool isJump = false;
    bool atGround = true;
    private float lastVertical = 0;
    [SerializeField] private LayerMask whatIsGround;   // check which layer is ground

    // facing left, right
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // horizontal movement
        float horizontal = joyStick.Horizontal;
        float hMove = 0;
        if (horizontal >= .2f)
        {
            if (!isFacingRight)
                Flip();
            hMove = speed;
        }
        else if (horizontal <= -.2f)
        {
            if (isFacingRight)
                Flip();
            hMove = -speed;
        }
         

        animator.SetFloat("Speed", Mathf.Abs(hMove));

        Vector3 movement = new Vector3(hMove * Time.deltaTime, 0, 0);
        transform.position += movement;

        // jumping
        float vertical = joyStick.Vertical;
        // only jump once when holding up key
        if (lastVertical < .2f && vertical >= .2f)
            isJump = true;
        lastVertical = vertical;

        if (isJump)
        {
            Jump();
            animator.SetBool("isJumping", true);
            isJump = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ground detection
        if (whatIsGround == (whatIsGround | 1 << collision.gameObject.layer))
        {
            atGround = true;
            animator.SetBool("isJumping", false);
        }
            
    }

    private void Jump()
    { 
        // if the player can jump (at the ground)
        if (atGround)
        {
            // add a vertical force
            Vector2 jumpMove = new Vector2(0, jump);
            rb.AddForce(jumpMove, ForceMode2D.Impulse);
            atGround = false;
        }
    }

    // Flip the sprite
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        transform.Rotate(0f, 180f, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadzone"))
        {
            FindObjectOfType<GameManager>().EndGame();
        }


    }
}
