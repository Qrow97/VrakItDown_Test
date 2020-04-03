using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    PlayerHealth playerHealth;
    private Slider slider;
    private float fillValue;

    

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        
        SetHealth(playerHealth.GetHealthNormalized());
        playerHealth.OnDamaged += HealthSystem_OnDamaged;
        playerHealth.OnHealed += HealthSystem_OnHealed;
        

    }

    private void Update()
    {
        fillValue = SetHealth(playerHealth.GetHealthNormalized());
        slider.value = fillValue;
    }

    private void HealthSystem_OnHealed(object sender, EventArgs e)
    {
        SetHealth(playerHealth.GetHealthNormalized());
    }

    private void HealthSystem_OnDamaged(object sender, EventArgs e)
    {
        SetHealth(playerHealth.GetHealthNormalized());
    }

    private float SetHealth(float healthNormalized)
    {
       return fillValue = playerHealth.GetHealthNormalized();
    }
}
