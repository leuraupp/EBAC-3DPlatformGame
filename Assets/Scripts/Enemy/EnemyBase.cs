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
        public bool lookAtPlayer = false;

        [SerializeField] private float currentLife;

        [Header("Animation")]
        [SerializeField] private AnimationBase animationBase;

        [Header("Start Animation")]
        public bool startAnimation = true;
        public float startAnimationTime = 0.5f;
        public Ease startAnimationEase = Ease.OutBack;

        private Player player;

        protected virtual void Awake() {
            Init();
        }

        private void Start() {
            player = GameObject.FindFirstObjectByType<Player>();
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
        public void Damage(float damage, Vector3 dir) {
            Debug.Log("Damage: " + damage, this);
            OnDamage(damage);
            transform.DOMove(transform.position + dir, 0.1f);
        }

        #region Animation
        public virtual void StartAnimation() {
            transform.DOScale(0, startAnimationTime).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType type) {
            animationBase.PlayAnimationByTrigger(type);
        }
        #endregion

        private void OnCollisionEnter(Collision collision) {
            Player p = collision.gameObject.GetComponent<Player>();
            if (p != null) {
                p.healthBase.Damage(10f);
            }
        }

        public virtual void Update() {
            if (lookAtPlayer) {
                transform.LookAt(player.transform.position);
            }
        }

    }

}

