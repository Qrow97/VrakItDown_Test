using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 100;
	private bool isInvulnerable = false;
	public GameObject damageEffect;	//damage, less blood
	public GameObject deathEffect;	//death, more blood


	public void TakeDamage(int damage)
	{ 
		if (isInvulnerable)
			return;
		health -= damage;
		Instantiate(damageEffect, transform.position, Quaternion.identity);

		if (health <= 0)
		{
			Die();
			Instantiate(deathEffect, transform.position, Quaternion.identity);	
		}
	}

	void Die()
	{
		isInvulnerable = true;
		GetComponent<Animator>().SetTrigger("isDead");
		Destroy(gameObject, 4);
	}
}
