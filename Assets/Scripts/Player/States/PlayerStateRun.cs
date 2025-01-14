using Ebac.StateMachine;
using UnityEngine;

public class PlayerStateRun : StateBase
{
    public override void OnStateEnter(Object o = null) {
        Debug.Log("Entrou no estado Run");
    }
    public override void OnStateStay() {
        Debug.Log("Continua no estado Run");
    }
    public override void OnStateExit() {
        Debug.Log("Saiu do estado Run");
    }
}
