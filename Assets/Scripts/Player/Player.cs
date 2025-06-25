using UnityEngine;
using Ebac.StateMachine;
using NUnit.Framework;
using System.Collections.Generic;

public class Player : MonoBehaviour//, IDamageable
{
    public List<Collider> colliders;

    [Header("Player")]
    public StateMachine<PlayerState> stateMachine;
    public CharacterController characterController;

    [Header("Movement")]
    public float speed = 1f;
    public float turnSpeed = 1f;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce = 15f;
    public float gravity = 9.8f;

    [Header("Animation")]
    public Animator animator;

    [Header("Run")]
    public KeyCode runKey = KeyCode.LeftShift;
    public float runSpeed = 1.5f;

    private bool isJumping = false;
    private float vSpeed = 0f;
    private bool isAlive = true;

    [Header("Flash")]
    public List<FlashColor> flashColor;

    [Header("Health")]
    public HealthBase healthBase;

    private void OnValidate() {
        if (healthBase == null) {
            healthBase = GetComponent<HealthBase>();
        }
    }

    private void Awake() {
        OnValidate();

        healthBase.OnDamage += Damage;
        healthBase.OnKill += Kill;
    }

    public enum PlayerState {
        Idle,
        Walk,
        Jump
    }

    private void Start() {
        stateMachine = new StateMachine<PlayerState>();
        stateMachine.Init();

        stateMachine.RegisterState(PlayerState.Idle, new PlayerStateIdle());
        stateMachine.RegisterState(PlayerState.Walk, new PlayerStateRun());
        stateMachine.RegisterState(PlayerState.Jump, new PlayerStateJump());
    }

    private void Update() {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        float vertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * vertical * speed;

        if (characterController.isGrounded) {
            vSpeed = 0;
            if (Input.GetKeyDown(jumpKey)) {
                vSpeed = jumpForce;
            }
            isJumping = false;
        } else {
            isJumping = true;
        }

        vSpeed -= gravity * 2f *Time.deltaTime;
        speedVector.y = vSpeed;

        var isWalking = vertical != 0;
        if (isWalking) {
            if (Input.GetKey(runKey)) {
                speedVector *= runSpeed;
                animator.speed = runSpeed;
            } else {
                animator.speed = 1;
            }
        }

        if (characterController.enabled) {
            characterController.Move(speedVector * Time.deltaTime);
        }

        if (vertical != 0) {
            animator.SetBool("Run", true);
        } else {
            animator.SetBool("Run", false);
        }

        if (!isJumping) {
            if (vertical != 0) {
                stateMachine.SwitchState(PlayerState.Walk);
            } else {
                stateMachine.SwitchState(PlayerState.Idle);
            }
        } else {
            stateMachine.SwitchState(PlayerState.Jump);
        }
    }
    private bool IsGrounded() {
        RaycastHit hit;
        float raycastDistance = 1f;
        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, raycastDistance)) {
            return true;
        }

        return false;
    }

    [NaughtyAttributes.Button("Kill")]
    public void Kill(HealthBase h) {
        if (isAlive) {
            isAlive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(c => c.enabled = false);
            Invoke(nameof(Revive), 3f);
        }
    }

    private void Revive() {
        isAlive = true;
        animator.SetTrigger("Revive");
        healthBase.ResetLife();
        Respawn();
        colliders.ForEach(c => c.enabled = true);
    }

    public void Damage(HealthBase h) {
        flashColor.ForEach(f => f.Flash());
    }

    public void Damage(float damage, Vector3 dir) {
        flashColor.ForEach(f => f.Flash());
    }

    public void Respawn() {
        if (CheckpointsManager.Instance.HasCheckpoint()) {
            transform.position = CheckpointsManager.Instance.GetPositionFromLastCheckpoint();
        }
    }
}
