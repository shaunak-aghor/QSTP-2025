using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontalInput;
    bool isGrounded;
    bool isFacingRight = true;

    public float speed;
    public float jumpSpeed;

    public Transform raycastOrigin;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            isFacingRight = true;
        }
        else
        {
            isFacingRight = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }


        if (Physics2D.Raycast(raycastOrigin.position, Vector2.down, 0.05f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isFacingRight)
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }
}
