using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacingDirection : MonoBehaviour
{

	public Transform player;

	public bool isFlipped = false;
	public GameObject fireEffect;   //enemy2 fire efekti
	public GameObject poisonEffect;

	public void FaceToPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			//look left
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			//look right
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
	
	void FireBreath()			//animasyon bu event'i cagiriyor
	{
		
		if(isFlipped==true)		//saga bakiyorsa alev 180 derece y ekseninde donuyor
		{
			Instantiate(fireEffect, transform.position, Quaternion.Euler(0f, 180f, 0f));
		}
		else					//sola bakiyorsa extra birsey yok
		{
			Instantiate(fireEffect, transform.position, Quaternion.identity);
		}
	}
	void PoisonBreath()
	{
		if (isFlipped == true)      //saga bakiyorsa alev 180 derece y ekseninde donuyor
		{
			Instantiate(poisonEffect, transform.position, Quaternion.Euler(0f, 180f, 0f));
		}
		else                    //sola bakiyorsa extra birsey yok
		{
			Instantiate(poisonEffect, transform.position, Quaternion.identity);
		}
	}
}
