using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AI
{
    // These are the varaibles all enemies have
    public int spell;
    public bool isUnlocked;
    public bool attacking;
    public GameObject enemyAttacking;

    public RoundManager roundManager;
    Round currentRound; 

    // This timer is compared with that attack speed to determine when an enemy attacks
    float attacktimer;

    int attackingIndex;

    public void TakeDamage(int healthLost) {
        this.health -= healthLost;
        if (this.health <= 0) {
            Destroy(gameObject);
            Debug.Log(this.name + " has died");
            roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();
            currentRound = roundManager.GetCurrentRound(); 
            currentRound.decreaseNumberOfEnemies();
        }
        Debug.Log(this.name + " took " + healthLost + " damage");
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
        if (enemyAttacking.tag == "Farmhouse") {
            enemyAttacking.GetComponent<FarmHouseHealth>().TakeDamage(this.attackPower);
        } else if (enemyAttacking.tag == "Animal") {
            enemyAttacking.GetComponent<Animal>().TakeDamage(this.attackPower, attackingIndex, this);
        } else {
            Debug.Log(this.name + " did not attack something with an animal or farmhouse tag");
        }
        attacktimer = 0.0f;
    }
}
