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
	}
    
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (!audioSource.isPlaying)
		{
			audioSource.PlayOneShot(RandomClip());
		}
    }
}
