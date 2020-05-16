using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    // Put all refrences to State Machine Objects here, these are methods that derive from state machine
    protected AI AI;

    public State(AI ai) {
        AI = ai;
    }

    // EnterState() runs when a state is first entered
    public abstract IEnumerator EnterState();

    // ExitState() runs when a state is exited
    public abstract IEnumerator ExitState();

    // UpdateState() runs every frame object is in certain state
    public abstract IEnumerator UpdateState();

}
