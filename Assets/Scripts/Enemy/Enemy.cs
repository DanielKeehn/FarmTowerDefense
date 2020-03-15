using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // These are the varaibles all enemies have
    public string name;
    public int health;
    public int spell;
    public bool isUnlocked;
    public int attackPower;
    public float attackSpeed;
    public bool attacking;
    public GameObject enemyAttacking;

    // This timer is compared with that attack speed to determine when an enemy attacks
    float attacktimer;

    // This is the contructor
    public Enemy(string n, int h, int s, bool u, int p, int sp, bool a, GameObject ea) {
        this.name = n;
        this.health = h;
        this.spell = s;
        this.isUnlocked = u;
        this.attackPower = p;
        this.attackSpeed = sp;
        this.attacking = a;
        this.enemyAttacking = ea;
    }


    // This is the contructor when no variables are given
    public Enemy() {
        this.name = "No Name";
        this.health = 0;
        this.spell = 0;
        this.isUnlocked = false;
        this.attackPower = 0;
        this.attackSpeed = 0.0f;
        this.attacking = false;
        this.enemyAttacking = null;
    }

    void Start()
    {
        attacktimer = 0.0f;
    }

    void Update()
    {
        // Checking for an attack only runs when this.attacking is true
        if (this.attacking) {
            checkForAttack(this.enemyAttacking);
        }
    }

    public void TakeDamage(int healthLost) {
        this.health -= healthLost;
        if (this.health <= 0) {
            Destroy(gameObject);
            Debug.Log(this.name + " has died");
        }
        Debug.Log(this.name + " took " + healthLost + " damage");
    }

    // This takes in the thing the enemy is attacking and begins the proccess of attacking
    public void BeginAttack(GameObject enemyAttacking) {
        Debug.Log("Attack Begun On " + enemyAttacking);
        attacking = true;
        this.enemyAttacking = enemyAttacking;
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
        }
        attacktimer = 0.0f;
    }
}
