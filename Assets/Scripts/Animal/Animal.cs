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

    public int attackPower;
    public float attackSpeed;
    public bool attacking;
    public GameObject enemyAttacking;

    // This timer is compared with that attack speed to determine when an enemy attacks
    float attacktimer;

    int attackingIndex;


    // This is the contructor
    public Animal(string n, int h, int c, bool u, int p, int sp, bool a, GameObject ea) {
        this.name = n;
        this.health = h;
        this.costToSpawn = c;
        isUnlocked = u;
        this.attackPower = p;
        this.attackSpeed = sp;
        this.attacking = a;
        this.enemyAttacking = ea;
    }


    // This is the contructor when no variables are given
    public Animal() {
        this.name = "No Name";
        this.health = 0;
        this.costToSpawn = 0;
        this.isUnlocked = false;
        this.attackPower = 0;
        this.attackSpeed = 0.0f;
        this.attacking = false;
        this.enemyAttacking = null;

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

    // This takes in the thing the enemy is attacking and begins the proccess of attacking
    public void BeginAttack(GameObject enemyAttacking, int index) {
        Debug.Log("Attack Begun On " + enemyAttacking);
        attacking = true;
        this.enemyAttacking = enemyAttacking;
        attackingIndex = index;
    }

    void checkForAttack(GameObject enemyAttacking) {
        attacktimer += Time.deltaTime;
        if (attacktimer >= this.attackSpeed) {
            Attack(enemyAttacking);
        }
    }

     void Attack(GameObject enemyAttacking) {
        if (enemyAttacking.tag == "Enemy") {
            enemyAttacking.GetComponent<Enemy>().TakeDamage(this.attackPower);
        } else {
            Debug.Log(this.name + " did not attack something with an animal or farmhouse tag");
        }
        attacktimer = 0.0f;
    }


}
