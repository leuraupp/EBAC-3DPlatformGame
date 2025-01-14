using UnityEngine;
using Ebac.StateMachine;

public class FSMExample : MonoBehaviour
{
    public enum ExampleState {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE
    }

    public StateMachine<ExampleState> stateMachine;

    private void Start() {
        stateMachine = new StateMachine<ExampleState>();
        stateMachine.Init();

        stateMachine.RegisterState(ExampleState.STATE_ONE, new StateBase());
        stateMachine.RegisterState(ExampleState.STATE_TWO, new StateBase());
        stateMachine.RegisterState(ExampleState.STATE_THREE, new StateBase());
    }
}
