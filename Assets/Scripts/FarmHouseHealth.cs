﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHouseHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBarScript healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    { 
    
    }

    // The barn house loses health every time this method is called
     public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
