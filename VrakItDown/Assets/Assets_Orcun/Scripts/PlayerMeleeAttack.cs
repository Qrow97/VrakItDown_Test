using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    private float timeBetweenAttack;
    public float startTimeBetweenAttack;

    public Transform attackPosition;
    public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public float boxAngle;
    public Animator animator;

 

    private void Update()
    {
        if(timeBetweenAttack <= 0)
        {
            //Able to attack
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("melee");
                timeBetweenAttack = startTimeBetweenAttack;
                // Created a circler area to deal damage, 3rd param makes it seach collider obj within the range 
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPosition.position, new Vector2(attackRangeX,attackRangeY), boxAngle, whatIsEnemies);
                for(int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
        }
        else
        {   
            //decrease it until able to attack
            timeBetweenAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        //making attack range visible in Unity editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosition.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
