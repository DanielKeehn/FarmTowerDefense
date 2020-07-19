using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{

    // The distance the AI is from its target 
    protected float targetDistance;
    public SearchState(AI ai): base(ai){

    }
    public override IEnumerator EnterState() {
        Debug.Log("A " + AI.name + " has entered search state");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator ExitState() {
        Debug.Log("A " + AI.name + " has exited search state");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator UpdateState() {
        if (FindClosestTarget()) {
            AI.agent.SetDestination(AI.currentTarget.transform.position);
        }
        if (CanAttack()) {
            AI.agent.isStopped = true;
            AI.animator.SetBool("CanAttack", true);
            AI.ChangeState(new AttackState(AI));
        } 
        yield return new WaitForSeconds(2f);
    }

    // Finds the closest target and updates closetTarget
    // Returns true if target is found and false if target is still null
    private bool FindClosestTarget() {
        // The distance you are currently checking
        float currentDistance;
        // List that contains all targets
        List<GameObject> targets = null;
        // Make initial distance positive infinity if no target was chosen previously
        if (AI.currentTarget == null) {
            targetDistance = float.PositiveInfinity;
        // Find the distance of the current target if current target isn't null
        } else {
            targetDistance = Vector3.Distance(AI.gameObject.transform.position, AI.currentTarget.transform.position);
        }

        // Get List of objects AI can target
        targets = AI.getTargetList();

        foreach (var target in targets) {
            currentDistance = Vector3.Distance(AI.gameObject.transform.position, target.transform.position);
            if (currentDistance < targetDistance) {
                targetDistance = currentDistance;
                AI.currentTarget = target;
            }
        }
        if (AI.currentTarget == null) {
            return false;
        } else {
            return true;
        } 
    }

    // Finds if an AI can attack a target or not depending on their range
    private bool CanAttack() {
        if (AI.currentTarget != null) {
            if (targetDistance < AI.attackRange) {
                return true;
            } else {
                return false;
            }
        }
        return false;
    }
}
