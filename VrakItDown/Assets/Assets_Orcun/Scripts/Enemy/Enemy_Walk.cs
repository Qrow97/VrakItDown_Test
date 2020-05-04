using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : StateMachineBehaviour
{
    [SerializeField] float agroRange;
    
    public float speed = 2.5f;
    Transform player;
    Rigidbody2D rigidBody;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //get enemy rigidbody
        rigidBody = animator.GetComponent<Rigidbody2D>();
        animator.SetBool("isPlayerInRange", false);
      
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        //get position of enemy and player
      
        /*  Vector2 target = new Vector2(player.position.x, rigidBody.position.y);
        //move current position to target position
        Vector2 newPosition = Vector2.MoveTowards(rigidBody.position, target, speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPosition);*/

        float distanceToPlayer = Vector2.Distance(rigidBody.position, player.position);
        

        if (distanceToPlayer < agroRange)
        {

            //chase player
            animator.SetBool("isPlayerInRange", true);
        }
     
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
