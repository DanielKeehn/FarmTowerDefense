using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // These are the varaibles all enemies have
    public string name;
    public int health;

    // This is the contructor
    public Enemy(string n, int h) {
        this.name = n;
        this.health = h;
    }


    // This is the contructor when no variables are given
    public Enemy() {
        this.name = "No Name";
        this.health = 100;

    }

    public void TakeDamage(int healthLost) {
        this.health -= healthLost;
        if (this.health <= 0) {
            Destroy(gameObject);
            Debug.Log(this.name + " has died");
        }
        Debug.Log(this.name + " took " + healthLost + " damage");
    }


}
