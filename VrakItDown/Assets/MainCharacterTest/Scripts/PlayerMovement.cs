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

    /*
    SavePlayerPosition playerPositionData;
    private void Awake()
    {
        playerPositionData = FindObjectOfType<SavePlayerPosition>();
        playerPositionData.PlayerPositionLoad();
    }
    */

    // Initialization
    private void Start()
    {
       
        animator = GetComponent<Animator>();

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

    }

    // FixedUpdate is called periodically
    private void FixedUpdate()
    {    

        controller.Move(horizontalMoveDirection * Time.fixedDeltaTime, false, jump, doubleJump);
        jump = false;
        doubleJump = false;

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
    }


}
