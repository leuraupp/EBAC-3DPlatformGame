using UnityEngine;
using Ebac.StateMachine;

public class Player : MonoBehaviour
{
    public StateMachine<PlayerState> stateMachine;

    private bool isJumping = false;

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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.position += movement * Time.deltaTime * 5f;
        if (!isJumping) {
            if (movement != Vector3.zero) {
                stateMachine.SwitchState(PlayerState.Walk);
            } else {
                stateMachine.SwitchState(PlayerState.Idle);
            }
        } else {
            stateMachine.SwitchState(PlayerState.Jump);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }

        if (IsGrounded()) {
            isJumping = false;
        } else {
            isJumping = true;
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
}
