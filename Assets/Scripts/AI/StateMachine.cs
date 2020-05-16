using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine: MonoBehaviour
{
    protected State State;

    public void ChangeState(State newState) {
        if (State != null) {
            StartCoroutine(State.ExitState());
        }
        State = newState;
        StartCoroutine(State.EnterState());
    }

    private void Update() {
        if (State != null) {
            StartCoroutine(State.UpdateState());
        }
    }
}
