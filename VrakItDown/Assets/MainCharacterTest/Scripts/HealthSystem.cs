using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;

    public int healthAmount;
    public int healthAmounthMax;

    public HealthSystem(int healthAmounthMax)
    {
        healthAmounthMax = healthAmount;
        this.healthAmount = healthAmounthMax;
    }

    public int GetHealth()
    {
        return healthAmount;
    }

    public void Damage(int damageAmount)
    {
        healthAmount -= damageAmount;

        if(healthAmount < 0)
        {
            healthAmount = 0;
        } 

        if(OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        healthAmount += healAmount;

        if(healthAmount > healthAmounthMax)
        {
            healthAmount = healthAmounthMax;
        }

        if (OnDamaged != null)
        {
            OnHealed(this, EventArgs.Empty);
        }
    }

    public float GetHealthNormalized()
    {
        return (float)healthAmount / healthAmounthMax;
    }
}
