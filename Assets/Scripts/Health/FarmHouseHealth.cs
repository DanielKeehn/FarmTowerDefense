using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHouseHealth : Health
{
    public HealthBarScript healthbar;

    // Reference to the lose state script
    private LoseState loseState;

    // Start is called before the first frame update
    protected override void Start()
    {
        // Find Lose State script
        loseState = GameObject.FindWithTag("GameManager").GetComponent<LoseState>();
        if (loseState == null) {
            throw new System.ArgumentException("Couldn't find reference to the lose state script");
        }

        base.Start();
        healthbar.SetMaxHealth(health);
        animalList.Add(gameObject);
    }

    // The barn house loses health every time this method is called
     public override void TakeDamage(int damage) {
        health -= damage;
        healthbar.SetHealth(health);
        IsDead();
    }

    public override bool IsDead() {
        if (health <= 0) {
            loseState.GoToLoseState();
            Debug.Log("YOU LOST");
            return true;
        } else {
            return false;
        }
    }
}
