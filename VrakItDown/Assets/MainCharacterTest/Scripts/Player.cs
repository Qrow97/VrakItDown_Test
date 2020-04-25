using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(20);
        }
    }

    // Reduces the players life by damageAmount 
     public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Instantiate(damageEffect, transform.position, Quaternion.identity); //damageEffect prefab cagirma
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Respawn();
        }

        healthBar.SetHealth(currentHealth);

    }

    // Fills the players life by healAmount 
    void Heal(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.SetHealth(currentHealth);
    }

    void Respawn()
    {
        transform.position = Vector3.zero;
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
    }
    
  

}
