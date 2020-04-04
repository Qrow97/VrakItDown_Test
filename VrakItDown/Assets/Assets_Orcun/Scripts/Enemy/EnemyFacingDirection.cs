using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacingDirection : MonoBehaviour
{

	public Transform player;

	public bool isFlipped = false;

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

}
