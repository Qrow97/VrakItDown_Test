using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health = 100;
	private Animation anim;
	private bool isInvulnerable = false;
	public GameObject damageEffect;	//damage, az kan
	public GameObject deathEffect;	//death, cok kan


	public void TakeDamage(int damage)
	{ 
		if (isInvulnerable)
			return;
		health -= damage;
		Instantiate(damageEffect, transform.position, Quaternion.identity);

		if (health <= 0)
		{
			Die();
			Instantiate(deathEffect, transform.position, Quaternion.identity);	//ölüm effect buraya ekledim. Die fonksiyonu icinde cagirdigin zaman bazen sorun cikiartiyordu.
		}
	}

	void Die()
	{
		isInvulnerable = true;
		GetComponent<Animator>().SetTrigger("isDead");
		
		
		Destroy(gameObject, 4);
	}
}
