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

    private RoundManager roundManager;
    Round currentRound;

    // This function checks if a vegetable has hit the barn collider
    // The Vegetable AI will go into attack mode when it hits the barn collider
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        if (other.tag == "Barn") {
            agent.isStopped = true;
            //animator.SetBool("CanAttack", true);
            ChangeState(new AttackState(this));
        }
    } 

}
