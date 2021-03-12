using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;

    public float moveSpeed = 1.0f;
    public float jumpSpeed = 1.0f, jumpFrequency = 1.0f, nextJumpTime;

    bool facingRight = true;

    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Awake()
    {
        
    }
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
        onGroundCheck();
        if (rigidbody2D.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }else if (rigidbody2D.velocity.x >= 0 && !facingRight)
        {
            FlipFace();
        }

        if (Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
        }
    }

    void FixedUpdate()
    {
        
    }

    void HorizontalMove()
    {
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rigidbody2D.velocity.y);
        animator.SetFloat("playerSpeed", Mathf.Abs(rigidbody2D.velocity.x));
    }

    void Jump()
    {
        rigidbody2D.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        animator.SetBool("hasJump", isGrounded);
    }

    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }
}
