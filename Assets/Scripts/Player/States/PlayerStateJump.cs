using Ebac.StateMachine;
using UnityEngine;

public class PlayerStateJump : StateBase
{
    public override void OnStateEnter(Object o = null) {
        Debug.Log("Entrou no estado Jump");
    }
    public override void OnStateStay() {
        Debug.Log("Continua no estado Jump");
    }
    public override void OnStateExit() {
        Debug.Log("Saiu do estado Jump");
    }
}
