using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Boss {

    public enum BossActions {
        INIT,
        IDLE,
        WALK,
        ATTACK,
        DEATH
    }

    public class BossBase : MonoBehaviour {
        [Header("Animation")]
        public float startAnimationDuration = .5f;
        public Ease startAnimationEase = Ease.OutBack;

        [Header("Animation")]
        public int attackAmount = 5;
        public float timeBetweenAttacks = 0.5f;

        public float speed = 5f;
        public List<Transform> points;

        public HealthBase healthbase;

        private StateMachine<BossActions> stateMachine;

        private void Awake() {
            Init();
            healthbase.OnKill += OnBossKill;
        }

        private void Init() {
            stateMachine = new StateMachine<BossActions>();
            stateMachine.Init();

            stateMachine.RegisterState(BossActions.INIT, new BossStateInit());
            stateMachine.RegisterState(BossActions.WALK, new BossStateWalk());
            stateMachine.RegisterState(BossActions.ATTACK, new BossStateAttack());
            stateMachine.RegisterState(BossActions.DEATH, new BossStateDeath());
        }

        private void OnBossKill(HealthBase h) {
            SwitchState(BossActions.DEATH);
        }

        #region ATTACK
        public void StartAttack(Action endCallback = null) {
            StartCoroutine(AttackCoroutine(endCallback));
        }

        IEnumerator AttackCoroutine(Action endCallback) {
            int attacks = 0;
            while (attacks < attackAmount) {
                attacks++;
                transform.DOScale(1.1f, .1f).SetLoops(2, LoopType.Yoyo);
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            endCallback?.Invoke();
        }
        #endregion

        #region ANIMATION
        public void StartInitAnimation() {
            StartCoroutine(StartInitAnimationCoroutine());
        }

        IEnumerator StartInitAnimationCoroutine() {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
            yield return new WaitForEndOfFrame();

            SwitchState(BossActions.WALK);
            Debug.Log("Init Animation Finished");
        }
        #endregion

        #region GOTOPOINT
        public void GoToRandomPoint(Action onArrive = null) {
            StartCoroutine(GoToPointCoroutine(points[UnityEngine.Random.Range(0, points.Count)], onArrive));
        }

        IEnumerator GoToPointCoroutine(Transform t, Action onArrive = null) {
            while (Vector3.Distance(transform.position, t.position) > 1f) {
                transform.position = Vector3.MoveTowards(transform.position, t.position, speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            onArrive?.Invoke();
        }
        #endregion

        #region DEBUG
        [NaughtyAttributes.Button]
        private void SwitchInit() {
            SwitchState(BossActions.INIT);
        }
        [NaughtyAttributes.Button]
        private void SwitchWalk() {
            SwitchState(BossActions.WALK);
        }
        [NaughtyAttributes.Button]
        private void SwitchAttack() {
            SwitchState(BossActions.ATTACK);
        }
        #endregion

        #region STATE MACHINE
        public void SwitchState(BossActions action) {
            stateMachine.SwitchState(action, this);
        }
        #endregion
    }
}
