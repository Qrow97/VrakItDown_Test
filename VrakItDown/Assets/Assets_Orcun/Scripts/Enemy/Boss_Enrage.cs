using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Enrage : StateMachineBehaviour
{
    public byte rgb_Red;
    public byte rgb_Green;
    public byte rgb_Blue;
    public byte transparancy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyHealth>().isInvulnerable = true;
        animator.SetBool("IsEnraged", false);
<<<<<<< HEAD

=======
>>>>>>> Test_Branch_Alper
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<EnemyHealth>().isInvulnerable = false;
        //after this anim, color of enemy changes permanantly, params rgb and transparancy
        //cenesi degismiyor, sanirim ilk buldugu sprite renderer daki color u degistiyor sadece, alttakinde hepsini bulup degistiriyor
        //animator.GetComponentInChildren<SpriteRenderer>().color = new Color32(243, 105, 105, 255);\

       //take all of the components those who have sprite renderer, and change it's color for all of them.
        Component[] childComponents = animator.GetComponentsInChildren<SpriteRenderer>();
       foreach(SpriteRenderer enemyColor in childComponents)
        {
            enemyColor.color = new Color32(255, 100, 100, 255);
        }
        


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
