using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
	
	public int attackDamage = 5;
	public int enragedAttackDamage = 15;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	public void EnemyAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colliderInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colliderInfo != null)
		{
			colliderInfo.GetComponent<Player>().TakeDamage(attackDamage);
		}
	}

	public void EnemyEnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colliderInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colliderInfo != null)
		{
			colliderInfo.GetComponent<Player>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
