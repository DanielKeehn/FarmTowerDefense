using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// State when an AI first enters the game world
public class SpawnState : State
{
    public SpawnState(AI ai): base(ai){

    }
    public override IEnumerator EnterState() {
        Debug.Log("Enter State");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator ExitState() {
        Debug.Log("Exit State");
        yield return new WaitForSeconds(2f);
    }

    public override IEnumerator UpdateState() {
        Debug.Log("Update State");
        yield return new WaitForSeconds(2f);
    }
}
