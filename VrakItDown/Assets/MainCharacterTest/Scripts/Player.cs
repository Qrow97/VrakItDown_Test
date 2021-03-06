﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public GameObject damageEffect; //damageEffect prefab buraya ekliyorsun.
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // updates every fixed time 
    private void FixedUpdate()
    {
        healthBar.SetHealth(currentHealth);
    }

    // Reduces the players life by damageAmount 
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        Instantiate(damageEffect, transform.position, Quaternion.identity); //damageEffect prefab cagirma

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        healthBar.SetHealth(currentHealth);

    }

    // Fills the players life by healAmount 
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(gameObject);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }


}
