using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 100;
	private Animation anim;
	private bool isInvulnerable = false;
	//public GameObject deathEffect;


	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		isInvulnerable = true;
		GetComponent<Animator>().SetTrigger("isDead");
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		
		Destroy(gameObject, 4);
	}
}
