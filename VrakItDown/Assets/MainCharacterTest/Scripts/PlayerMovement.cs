using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public CharacterController2D controller;
    private Animator animator;

    [Header("Horizontal Movement")]
    public float horizontalMoveDirection = 0f;
    public float runSpeed = 40f;

    [Header("Vertical Movement")]
    public bool jump = false;
    public bool doubleJump = false;
    public bool canDoubleJump = false;
    public bool doubleJumpAnimation = false;

    [Header("Others")]
    public bool isGrounded;
	public float isDashing = 1;

    [Header("Dash Movement")]
    public Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    




    // Initialization
    private void Start()
    {
       
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {
        // Player Input
        horizontalMoveDirection = Input.GetAxisRaw("Horizontal") * runSpeed;

        // GroundCheck by controller
        isGrounded = controller.m_Grounded;

        // [-] :)
        Jump();
        Animator();
        DashMove();




    }

    // FixedUpdate is called periodically
    private void FixedUpdate()
    {    

        controller.Move(horizontalMoveDirection * Time.fixedDeltaTime, false, jump, doubleJump);
        jump = false;
        doubleJump = false;
		if(isDashing>1)
		{
			isDashing = isDashing - 1;
		}
		

    }

    

    //Jump && DoubleJump && DoubleJumpAnimaton
    private void Jump()
    {
        if (isGrounded)
        {
            doubleJumpAnimation = false;
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
            canDoubleJump = true;

        }
        else if (!isGrounded && Input.GetButtonDown("Jump") && canDoubleJump)
        {
            doubleJump = true;
            canDoubleJump = false;
            doubleJumpAnimation = true;
        }
        
    }

    //Animator initialization
    private void Animator()
    {
        animator.SetBool("canDoubleJump", doubleJumpAnimation);
        animator.SetBool("grounded", isGrounded);
        animator.SetFloat("velocityX", Mathf.Abs(horizontalMoveDirection) );
		animator.SetFloat("dashing", isDashing);
    }

    private void DashMove()
    {

        
            if (direction == 0)
            {
                if (Input.GetButtonDown("Dash") && horizontalMoveDirection < 0)
                {
                    direction = 1;
                }
                else if (Input.GetButtonDown("Dash") && horizontalMoveDirection > 0)
                {
                    direction = 2;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        rb.AddForce(new Vector2(-dashSpeed, 0f));
                        isDashing = 10;

                    }
                    else if (direction == 2)
                    {
                        rb.AddForce(new Vector2(dashSpeed, 0f));
                        isDashing = 10;
                    }
                }
            }
        

        
    }

    


}
