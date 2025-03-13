using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine {
    public class StateBase {
        public virtual void OnStateEnter(Object o = null) {
        }

        public virtual void OnStateStay() {
        }

        public virtual void OnStateExit() {
        }
    }
}
