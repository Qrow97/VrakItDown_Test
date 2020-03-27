using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public float speed;
    private float actualSpeed;

    public GameObject damageEffect;
    private Animator anim;

    private float dazedTime;
    public float startDazedTime;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isRunning", true);
        actualSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
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
