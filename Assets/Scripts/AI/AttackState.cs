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
                
                // Remove current target from the list of current attackable objects
                List<GameObject> targets = AI.getTargetList();
                if (targets != null) {
                    targets.Remove(AI.currentTarget);
                } else {
                    throw new System.ArgumentException("Couldn't remove destroyed target from list or find list");
                }
                AI.agent.isStopped = false;
                AI.currentTarget = null;
                //AI.animator.SetBool("CanAttack", false);
                AI.ChangeState(new SearchState(AI));
            }
        }
        yield return new WaitForSeconds(2f);
    }

    // This method checks if the AI can attack
    private bool checkForAttack() {
        // Make sure target has not already been killed by another AI
        if (AI.currentTarget == null) {
            AI.ChangeState(new SearchState(AI));
        }
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
            AI.aIAudioPlayer.PlayAttackSound();
        } catch {
            throw new System.ArgumentException("Couldn't Attack Target, make sure target has a health script");
        }
        attackTimer = 0.0f;
    }
}
