using UnityEngine;
using DG.Tweening;
using Animation;

namespace Enemy {
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public Collider collider;
        public FlashColor flashColor;
        public ParticleSystem particleSystem;
        public float startLife = 100f;

        [SerializeField] private float currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase animationBase;

        [Header("Start Animation")]
        public bool startAnimation = true;
        public float startAnimationTime = 0.5f;
        public Ease startAnimationEase = Ease.OutBack;

        protected virtual void Awake() {
            Init();
        }

        protected virtual void Init() {
            ResetLife();

            if (startAnimation) {
                StartAnimation();
            }
        }

        protected void ResetLife() {
            currentLife = startLife;
        }

        protected virtual void Kill() {
            OnKill();
        }

        protected virtual void OnKill() {
            Destroy(gameObject, 3f);
            PlayAnimationByTrigger(AnimationType.DEATH);
            if (collider != null) {
                collider.enabled = false;
            }
        }

        public void OnDamage(float damage) {
            if (flashColor != null) {
                flashColor.Flash();
            }

            if (particleSystem != null)
            {
                particleSystem.Emit(15);
            }

            currentLife -= damage;
            if (currentLife <= 0) {
                Kill();
            }
        }

        public void Damage(float damage) {
            Debug.Log("Damage: " + damage, this);
            OnDamage(damage);
        }

        #region Animation
        public virtual void StartAnimation() {
            transform.DOScale(0, startAnimationTime).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType type) {
            animationBase.PlayAnimationByTrigger(type);
        }
        #endregion

        #region Debug
        private void Update() {
            if (Input.GetKeyDown(KeyCode.K)) {
               OnDamage(50f);
            }
        }
        #endregion

    }

}

