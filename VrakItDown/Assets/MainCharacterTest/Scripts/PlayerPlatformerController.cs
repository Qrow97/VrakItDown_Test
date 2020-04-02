using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    private int amountOfJumpsLeft;
    public int amountOfJumps = 1;

    public float maxSpeed = 7;
    public float jumpForce = 7;


    private bool facingRight = false;
    private bool canJump;
    public bool canDoubleJump = false;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private BoxCollider2D capsuleCollider2D;
    private Rigidbody2D rigidbody2D;
    

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected override void ComputeVelocity()
    {

        //Horizontal Movement
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        targetVelocity = move * maxSpeed;


        
        
        if (facingRight == false && move.x < 0)
        {
            Flip();
        }
        else if (facingRight == true && move.x > 0)
        {
            Flip();
        }

        CheckIfCanJump();
        Jump();
        Animator();
        
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void Animator()
    {
        animator.SetBool("canDoubleJump", canDoubleJump);
        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);
    }

    private void CheckIfCanJump()
    {
        if (grounded)
        {
            amountOfJumpsLeft = amountOfJumps;
        }

        

        if (amountOfJumpsLeft <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }

    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded && canJump)
        {
            velocity.y = jumpForce;
            amountOfJumpsLeft--;
        }
        else if (Input.GetButtonDown("Jump") && !grounded && canJump)
        {
            velocity.y = jumpForce;
            amountOfJumpsLeft--;
            canDoubleJump = true;
        }
        else if (grounded)
        {
            canDoubleJump = false;
        }

    }



}