using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHouseHealth : Health
{
    public HealthBarScript healthbar;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        healthbar.SetMaxHealth(health);
        animalList.Add(gameObject);
    }

    // The barn house loses health every time this method is called
     public override void TakeDamage(int damage) {
        health -= damage;
        healthbar.SetHealth(health);
    }

    public override bool IsDead() {
        if (health <= 0) {
            Debug.Log("YOU LOST");
            return true;
        } else {
            return false;
        }
    }
}
