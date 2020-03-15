using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This the class where all animals derive from the player spawns

public class Animal: MonoBehaviour
{

    // These are the varaibles all animals have
    public string name;
    public int health;
    public int costToSpawn;
    public bool isUnlocked;
    // attack pattern

    // This is the contructor
    public Animal(string n, int h, int c, bool u) {
        this.name = n;
        this.health = h;
        this.costToSpawn = c;
        isUnlocked = u;
    }


    // This is the contructor when no variables are given
    public Animal() {
        this.name = "No Name";
        this.health = 0;
        this.costToSpawn = 0;
        this.isUnlocked = false;

    }

    public void TakeDamage(int damage, int index) {
        this.health -= damage;
        Debug.Log(this.name + " took " + damage + " damage");
        checkForDead(index);
    }

    void checkForDead(int index) {
        if (this.health <= 0) {
            ArrayList spawnedAnimals =  GameObject.FindObjectOfType<SpawnManager>().getSpawnedAnimalsArray();
            spawnedAnimals.RemoveAt(index); 
            Destroy(gameObject);
        }
    }

}
