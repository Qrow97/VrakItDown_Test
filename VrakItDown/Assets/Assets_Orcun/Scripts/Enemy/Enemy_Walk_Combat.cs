using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk_Combat : StateMachineBehaviour
{

    public string attackTriggerName = "Attack";
    public float agroRange;
    public float stoppingDistance;
    public float attackRange = 3f;
    public float speed = 2.5f;

    Transform player;
    Rigidbody2D rigidBody;
    EnemyFacingDirection enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //find the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //get enemy rigidbody
        rigidBody = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<EnemyFacingDirection>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.FaceToPlayer();
        float distanceToPlayer = Vector2.Distance(rigidBody.position, player.position);
        
        if (distanceToPlayer < agroRange && distanceToPlayer > stoppingDistance)
        {

            //chase player
            ChasePlayer();
            
        }
        else if (distanceToPlayer <= stoppingDistance)
        {   
            //stay on current position
            rigidBody.position = this.rigidBody.position;
        }
        else
        {
            //stop chasing player
            animator.SetBool("isPlayerInRange", false);
            
        }


        if (Vector2.Distance(player.position, rigidBody.position) <= attackRange)
        {
            animator.SetTrigger(attackTriggerName);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(attackTriggerName);
    }
    

    private void ChasePlayer()
    {
        Vector2 target = new Vector2(player.position.x, rigidBody.position.y);
        //move current position to target position
        Vector2 newPosition = Vector2.MoveTowards(rigidBody.position, target, speed * Time.fixedDeltaTime);
        rigidBody.MovePosition(newPosition);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
