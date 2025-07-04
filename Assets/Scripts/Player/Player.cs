using UnityEngine;
using Ebac.StateMachine;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using System.Collections;
using Cloth;

public class Player : Singleton<Player>//, IDamageable
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

    [Space] 
    [SerializeField] private ClothChanger clothChanger;

    private void OnValidate() {
        if (healthBase == null) {
            healthBase = GetComponent<HealthBase>();
        }
    }

    protected override void Awake() {
        base.Awake();
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

        if (SaveManager.Instance.LoadLastCheckpoint() > 0) {
            Respawn();
        }
        healthBase.LoadHealth();
    }

    private void Update() {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        float vertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * vertical * speed;

        if (characterController.isGrounded) {
            if (isJumping) {
                isJumping = false;
                animator.SetTrigger("Land");
            }

            vSpeed = 0;
            if (Input.GetKeyDown(jumpKey)) {
                vSpeed = jumpForce;

                if (!isJumping) {
                    isJumping = true;
                    animator.SetTrigger("Jump");
                }

            }
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
        EffectsManager.Instance.TakeDamageEffect();
        EffectsManager.Instance.CameraShake(3f, 3f, 0.5f);
        SaveManager.Instance.SavePlayerHealth(h.GetCurrentLife());
    }

    public void Damage(float damage, Vector3 dir) {
        flashColor.ForEach(f => f.Flash());
    }

    public void Respawn() {
        if (CheckpointsManager.Instance.HasCheckpoint()) {
            transform.position = CheckpointsManager.Instance.GetPositionFromLastCheckpoint();
        }
    }

    public void ChangeSpeed(float newSpeed, float duration) {
        StartCoroutine(ChangeSpeedCoroutine(newSpeed, duration));
    }

    IEnumerator ChangeSpeedCoroutine(float newSpeed, float duration) {
        var defaultSpeed = speed;
        speed = newSpeed;
        animator.speed = newSpeed;
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
        animator.speed = defaultSpeed;
    }

    public void ChangeGravity(float newGravity, float newJumpForce, float duration) {
        StartCoroutine(ChangeGravityCoroutine(newGravity, newJumpForce, duration));
    }

    IEnumerator ChangeGravityCoroutine(float newGravity, float newJumpForce, float duration) {
        var defaultGravity = gravity;
        var defaultJumpForce = jumpForce;
        gravity = newGravity;
        jumpForce = newJumpForce;
        yield return new WaitForSeconds(duration);
        gravity = defaultGravity;
        jumpForce = defaultJumpForce;
    }

    public void ChangeTexture(ClothSetup clothSetup, float duration) {
        StartCoroutine(ChangeTextureCoroutine(clothSetup, duration));
    }

    IEnumerator ChangeTextureCoroutine(ClothSetup clothSetup, float duration) {
        clothChanger.ChangeTexture(clothSetup);
        yield return new WaitForSeconds(duration);
        clothChanger.ResetTexture();
    }


}
