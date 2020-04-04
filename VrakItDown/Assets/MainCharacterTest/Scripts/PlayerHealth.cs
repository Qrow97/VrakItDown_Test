using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{

    HealthSystem healthSystem;
    public int playerHealth;

    public PlayerHealth(int healthAmounthMax) : base(healthAmounthMax)
    {
        this.playerHealth = healthAmounthMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem(playerHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (healthSystem.GetHealth() == 100)
        {
            healthSystem.Damage(20);
        }
        
    }
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        //Test purposes
        Debug.Log("Taking DMG");
        if (playerHealth <= 0)
        {
            //die
        }
    }
}
