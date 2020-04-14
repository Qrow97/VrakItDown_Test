using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	//public GameObject blood;
	public int health = 100;
	private Animation anim;
	private bool isInvulnerable = false;
	public GameObject deathEffect;


	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
		health -= damage;

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
