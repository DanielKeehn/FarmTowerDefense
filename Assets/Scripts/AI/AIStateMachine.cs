namespace AIStateNamespace {
    public class AIStateMachine<T> {

    public AIState<T> currentState {get; private set;}

        // The object that is using the state machine
        public T Owner;

        // Constructor assigns Owner and makes null current state
        public AIStateMachine(T owner) {
            Owner = owner;
            currentState = null;
        }

        public void ChangeState(AIState<T> newState) {
            if (currentState != null) {
                currentState.ExitState(Owner);
            }
            currentState = newState;
            currentState.EnterState(Owner);
        }

        public void Update() {

            if (currentState != null) {
                currentState.UpdateState(Owner);
            }
        }
    }

    public abstract class AIState<T> {
        public abstract void EnterState(T owner);
        public abstract void ExitState(T owner);
        public abstract void UpdateState(T owner);

    }

}
