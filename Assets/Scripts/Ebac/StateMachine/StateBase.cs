using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine {
    public class StateBase {
        public virtual void OnStateEnter(params object[] objs) {
        }

        public virtual void OnStateStay() {
        }

        public virtual void OnStateExit() {
        }
    }
}
