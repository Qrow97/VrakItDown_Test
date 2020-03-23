using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private bool facingRight = true;
    
    private SpriteRenderer spriteRenderer;
    private Animator animator;
   


    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        Jump();

        if (facingRight == false && move.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && move.x < 0)
        {
            Flip();
        }

        animator.SetBool("grounded", grounded);
        animator.SetBool("canDoubleJump", canDoubleJump);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            canDoubleJump = true;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpTakeOffSpeed), ForceMode2D.Impulse);
            
        }
        else if (Input.GetButtonDown("Jump") && canDoubleJump == true && grounded == false)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpTakeOffSpeed), ForceMode2D.Impulse);
			canDoubleJump = false;
        }
        else if(grounded == true)
        {
            canDoubleJump = false;
        }
        

    }
}
    


