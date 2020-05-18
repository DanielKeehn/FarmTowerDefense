using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
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
        yield return new WaitForSeconds(2f);
    }

    // Finds the closest target and updates closetTarget
    // Returns true if target is found and false if target is still null
    private bool FindClosestTarget() {
        // Initialize the currentTarget and currentTarget distance
        float closestTargetDistance;
        // The distance you are currently checking
        float currentDistance;
        // Make initial distance positive infinity if no target was chosen previously
        if (AI.currentTarget == null) {
            closestTargetDistance = float.PositiveInfinity;
        // Find the distance of the current target if current target isn't null
        } else {
            closestTargetDistance = Vector3.Distance(AI.gameObject.transform.position, AI.currentTarget.transform.position);
        }
        foreach (var target in AI.targets) {
            currentDistance = Vector3.Distance(AI.gameObject.transform.position, target.transform.position);
            if (currentDistance < closestTargetDistance) {
                closestTargetDistance = currentDistance;
                AI.currentTarget = target;
            }
        }
        if (AI.currentTarget == null) {
            return false;
        } else {
            return true;
        } 
    }
}
