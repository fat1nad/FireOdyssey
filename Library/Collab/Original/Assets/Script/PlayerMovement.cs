using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    // For horizontal movement
    public float runSpeed;

    public Transform feetPos;
    //public FeetCollision feet;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsMirror;
    public LayerMask whatIsLowestGround;
    public float mirrorJumpForce;
    public float groundJumpForce;
    public float groundJumpTime;
    public float mirrorJumpTime;

    // For fatal jump
    public float fatalFallHeight;

    Rigidbody2D rb;

    // For horizontal movement
    float jH;
    float horizontalMove;
    Animator anim;

    // For Jump mechanism
    float jV;
    bool isGrounded;
    bool isOnMirror;
    bool isOnLowestGround;
    float jumpForce;
    bool isJumping;
    float jumpTimeCounter;
    public bool MirrorJump;
    // to be called in Mirror script - Z
 

    // For fatal jump
    float fellFromHeight;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()  
    {
        //isOnMirror = feet.isOnMirror;

        //isGrounded = feet.isGrounded;

        //isOnLowestGround = feet.isOnLowestGround;

        isOnMirror = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsMirror);

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        isOnLowestGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsLowestGround);

        if (isOnMirror)
        {
            isGrounded = isOnMirror;
            jumpForce = mirrorJumpForce;
            fellFromHeight = transform.position.y;
        }
        else if (isOnLowestGround) 
        {
            if (fellFromHeight >= fatalFallHeight)
            {
                fellFromHeight = transform.position.y;
                GetComponent<PlayerDeath>().FallDeath();
            }

            isGrounded = isOnLowestGround;
            jumpForce = groundJumpForce;
        }
        else if (isGrounded)
        {
            jumpForce = groundJumpForce;
            fellFromHeight = transform.position.y;
        }
    }

    void FixedUpdate()
    {
        jH = joystick.Horizontal;
        jV = joystick.Vertical;


        if (jH >= 0.2f)
        {
            horizontalMove = +runSpeed;

            anim.SetBool("isWalking", true);
            transform.eulerAngles = Vector3.zero;
        }
        else if (jH <= -0.2f)
        {
            horizontalMove = -runSpeed;

            anim.SetBool("isWalking", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            horizontalMove = 0;
            anim.SetBool("isWalking", false);
        }

        if ((isGrounded) && (jV >= 0.5f))
        {
            isJumping = true;

            if (isOnMirror)
            {
                
                jumpTimeCounter = mirrorJumpTime;
                MirrorJump = true;
                // - Z
            }
            else
            {
                jumpTimeCounter = groundJumpTime;
            }

            rb.velocity = Vector2.up * jumpForce;
        }

        if ((jV >= 0.5f) && (isJumping))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.fixedDeltaTime;
            }
            else
            {
                isJumping = false;

            }
        }

        if (jV < 0.5f)
        {
            isJumping = false;
        }

        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
