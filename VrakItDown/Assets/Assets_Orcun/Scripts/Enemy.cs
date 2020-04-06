using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    [SerializeField] float speed;
    private float actualSpeed;

    //public GameObject damageEffect;
    private Animator anim;

    private float dazedTime;
    public float startDazedTime;

    [SerializeField] Transform player;
    [SerializeField] float agroRange;
    [SerializeField] float stoppingDistance;

    //Rigidbody2D rigidBody;

    void Start()
    {   
        //get Rigidbody of the enemy
        //rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        //test purposes
        //print("Distance to player: " + distanceToPlayer);
        
        if(distanceToPlayer < agroRange && distanceToPlayer > stoppingDistance)
        {

            //chase player
            ChasePlayer();
        }
        else if(distanceToPlayer <= stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else
        {
      
            //stop chasing player
            StopChasePlayer();
        }
        
        //this make enemy stop a little bit when attacked
        if(dazedTime <= 0)
        {
            speed = actualSpeed;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if(health <= 0)
        {
            // add a dead animation here 
            Destroy(gameObject);
        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    private void StopChasePlayer()
    {
        
        transform.Translate(Vector2.zero * speed * Time.deltaTime);
    }

    private void ChasePlayer()
    {
        
        if(transform.position.x < player.position.x)
        {
            //enemy on the left side of player, so move right
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //face to player, make sure it's same scale as enemy
            transform.localScale = new Vector2((float)-0.1, transform.localScale.y);
        }
        else
        {
            //enemy on the right side of player, so move left
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //face to player
            transform.localScale = new Vector2((float)0.1, transform.localScale.y);
        }
    }

    public void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        // adding effects if there is
        //Instantiate(damageEffect, transform.position, Quaternion.identity);
        health -= damage;
        //Test purposes(delete afterwards)
        Debug.Log("Damage Taken");
    }
}
