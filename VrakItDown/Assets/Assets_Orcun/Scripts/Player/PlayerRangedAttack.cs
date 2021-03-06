﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangedAttack : MonoBehaviour
{
    // Start is called before the first frame update
    //if weapon start with a weird angle use offset
    public float offset;
    public Transform shotPoint;
    //timer purposes
    private float timeBetweenShots;
    public float startBetweenShots;
    
    public GameObject projectile;
	public AudioSource audioSource;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        //calculate distance between weapon and cursor
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //calculate degree according to cursor so weapon would rotate
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if(timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("Ranged attack Used");
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBetweenShots = startBetweenShots;
				audioSource.Play();
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

        
    }
}
