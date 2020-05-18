using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for animals

public class Animal: AI
{
    // These are the varaibles all animals have that other AI do not
    // How much it costs to spawn an animal 
    public int costToSpawn;
    // If an animal is unlocked
    public bool isUnlocked;
    // If an animal is attacking
    public bool attacking;
    // The enemy an animal is attacking
    public GameObject enemyAttacking;

    // This timer is compared with that attack speed to determine when an enemy attacks
    float attacktimer;

    int attackingIndex;

    public void TakeDamage(int damage, int index, Enemy enemy) {
        this.health -= damage;
        Debug.Log(this.name + " took " + damage + " damage");
        checkForDead(index, enemy);
    }

    void checkForDead(int index, Enemy enemy) {
        if (this.health <= 0) {
            ArrayList spawnedAnimals =  GameObject.FindObjectOfType<SpawnManager>().getSpawnedAnimalsArray();
            spawnedAnimals.RemoveAt(index);
            enemy.attacking = false;
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
