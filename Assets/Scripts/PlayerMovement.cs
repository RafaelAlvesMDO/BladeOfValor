using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float walkingSpeed = 6;
    private float jumpingSpeed = 10;

    private float horizontalInput;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Unstick Player on Wall
        if (onWall() && !isGrounded() && Mathf.Sign(horizontalInput) == transform.localScale.x)
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(horizontalInput * walkingSpeed, body.velocity.y);
        }

        // Side Looking
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        // Animator Parameters
        anim.SetBool("walk", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetFloat("velocityY", body.velocity.y);
        
        // Jump Trigger
        if (Input.GetKey(KeyCode.Space) && isGrounded())
            Jump();

        // Fall Trigger
        if (body.velocity.y < -0.01f && !isGrounded())
            Fall();
        }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpingSpeed);
        anim.SetTrigger("jump");
    }

    private void Fall()
    {
        anim.SetTrigger("fall");
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
        Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0,
        new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}
