using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All objects that are attackable must have this script attached

public class Health : MonoBehaviour
{
    public int health;

    // This method runs when something attacks an object with this attribute 
    public void TakeDamage(int amount) {
        health -= amount;
    }

    // Check if you are dead by running this method. Object is destroyed if dead
    public bool IsDead() {
        if (health <= 0) {
            Destroy(gameObject);
            return true;
        } else {
            return false;
        }
    }

}
