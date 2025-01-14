using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine {
    public class StateBase {
        public virtual void OnStateEnter(Object o = null) {
            Debug.Log("Entrou no estado");
        }

        public virtual void OnStateStay() {
            Debug.Log("Continua no estado");
        }

        public virtual void OnStateExit() {
            Debug.Log("Saiu do estado");
        }
    }
}
