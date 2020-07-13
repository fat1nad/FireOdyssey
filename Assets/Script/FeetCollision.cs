using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCollision : MonoBehaviour
{
    public bool isOnMirror;
    public bool isGrounded;
    public bool isOnLowestGround;

    void Start()
    {
        isOnMirror = false;
        isGrounded = false;
        isOnLowestGround = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GlassPlatform"))
        {
            isOnMirror = true;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("LowestGround"))
        {
            isOnLowestGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("GlassPlatform"))
        {
            isOnMirror = false;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        else if (collision.gameObject.CompareTag("LowestGround"))
        {
            isOnLowestGround = false;
        }
    }
}
