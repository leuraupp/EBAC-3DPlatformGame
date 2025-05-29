using System.Collections.Generic;
using UnityEngine;

namespace Animation {

    public enum AnimationType {
        NONE,
        IDLE,
        RUN,
        ATTACK,
        DEATH
    }

    public class AnimationBase : MonoBehaviour {

        public Animator animator;
        public List<AnimationSetup> animationSetups;

        public void PlayAnimationByTrigger(AnimationType type) {
            var setup = animationSetups.Find(a => a.animationType == type);
            if (setup != null) {
                animator.SetTrigger(setup.trigger);
            } else {
                Debug.Log("Animation not found for type: " + type, this);
            }
        }
    }

    [System.Serializable]
    public class AnimationSetup {
        public AnimationType animationType;
        public string trigger;
    }
}
