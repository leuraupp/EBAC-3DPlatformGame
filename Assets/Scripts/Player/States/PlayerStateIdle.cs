using Ebac.StateMachine;
using UnityEngine;

public class PlayerStateIdle : StateBase
{
    public override void OnStateEnter(Object o = null) {
        Debug.Log("Entrou no estado Idle");
    }
    public override void OnStateStay() {
        Debug.Log("Continua no estado Idle");
    }
    public override void OnStateExit() {
        Debug.Log("Saiu do estado Idle");
    }
}
