using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int health;
	private int maxHealt;
	public int enrageHealthForBoss;
	public int rageCheck = 0;
	[SerializeField] public bool isInvulnerable = false;
	public HealthBar healthBar;

	public GameObject damageEffect;	//damage, less blood
	public GameObject deathEffect;  //death, more blood
	void Start()
	{
		
		healthBar.SetMaxHealth(health);
	}

	public void TakeDamage(int damage)
	{ 
		if (isInvulnerable)
		{
			return;
		}
		else
		{
			health -= damage;
			healthBar.SetHealth(health);
			Instantiate(damageEffect, transform.position, Quaternion.identity);
			if (health < enrageHealthForBoss & rageCheck==0)
			{

				GetComponent<Animator>().SetBool("IsEnraged", true);
				rageCheck = 1;

			}
			if (health <= 0)
			{
				Die();
				Instantiate(deathEffect, transform.position, Quaternion.identity);
			}
		}	
		
	}

	void Die()
	{
		isInvulnerable = true;
		GetComponent<Animator>().SetTrigger("isDead");
		Destroy(gameObject, 4);
	}
}
