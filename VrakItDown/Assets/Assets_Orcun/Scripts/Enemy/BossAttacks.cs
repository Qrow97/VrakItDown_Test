using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public Transform attackPositionClose;
    public Transform attackPositionLong;
    public LayerMask whatIsEnemies;
    
    public float CloseAttackRangeX;
    public float CloseAttackRangeY;

    public float LongAttackRangeX;
    public float LongAttackRangeY;


    public float boxAngle;

    public int closeRangeAttackDmg1;
    public int closeRangeAttackDmg2;
    public int closeRangeAttackDmg3;
    public int closeRangeAttackDmg4;
    public int longRangeAttackDmg1;
    

    public void CloseRangeAttack1()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPositionClose.position, new Vector2(CloseAttackRangeX, CloseAttackRangeY), boxAngle, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(closeRangeAttackDmg1);
        }
    }
    public void CloseRangeAttack2()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPositionClose.position, new Vector2(CloseAttackRangeX, CloseAttackRangeY), boxAngle, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(closeRangeAttackDmg2);
        }
    }
    public void CloseRangeAttack3()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPositionClose.position, new Vector2(CloseAttackRangeX, CloseAttackRangeY), boxAngle, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(closeRangeAttackDmg3);
        }
    }
    public void CloseRangeAttack4()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPositionClose.position, new Vector2(CloseAttackRangeX, CloseAttackRangeY), boxAngle, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(closeRangeAttackDmg4);
        }
    }
    public void LongRangeAttack()
    {
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPositionLong.position, new Vector2(LongAttackRangeX, LongAttackRangeY), boxAngle, whatIsEnemies);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Player>().TakeDamage(longRangeAttackDmg1);
        }
    }
    private void OnDrawGizmosSelected()
    {
        //making attack range visible in Unity editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPositionClose.position, new Vector3(CloseAttackRangeX, CloseAttackRangeY, 1));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackPositionLong.position, new Vector3(LongAttackRangeX, LongAttackRangeY, 1));
    }
}
