using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    // This timer keeps track of when enemy can attack
    protected float attackTimer;
    public AttackState(AI ai): base(ai){

    }
    public override IEnumerator EnterState() {
        Debug.Log("A " + AI.name + " has entered attack state");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator ExitState() {
        Debug.Log("A " + AI.name + " has exited attack state");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator UpdateState() {
        if (checkForAttack()) {
            Attack();
            // Check if target is destroyed
            if (AI.currentTarget.GetComponent<Health>().IsDead()) {
                AI.targets.Remove(AI.currentTarget);
                AI.currentTarget = null;
                AI.ChangeState(new SearchState(AI));
            }
        }
        yield return new WaitForSeconds(2f);
    }

    // This method checks if the AI can attack
    private bool checkForAttack() {
        attackTimer += Time.deltaTime;
        if (attackTimer >= AI.attackSpeed) {
            return true;
        } else {
            return false;
        }
    }

    // The AI attacks when this method is run
    private void Attack() {
        try {
            AI.currentTarget.GetComponent<Health>().TakeDamage(AI.attackPower);
        } catch {
            Debug.Log("Could not attack object, make sure the object has a health script attached");
        }
        attackTimer = 0.0f;
    }
}
