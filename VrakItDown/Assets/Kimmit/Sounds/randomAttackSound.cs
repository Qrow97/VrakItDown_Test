using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomAttackSound : MonoBehaviour
{
	public AudioSource audioSource;
	public AudioClip[] audioClipArray;
	
	AudioClip RandomClip()
	{
    return audioClipArray[Random.Range(0, audioClipArray.Length-1)];
	//array.length mi, array.lenght-1 mi olmasi gerektiginde emin olamadim. Sonra kontrol edicem.
	}
	
    void Update()
    {
		if (!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(RandomClip());
		}
    }
}
