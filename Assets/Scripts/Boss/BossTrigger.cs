using Boss;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public BossBase boss;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            boss.gameObject.SetActive(true);
            boss.SwitchState(BossActions.INIT);
            Destroy(gameObject);
        }
    }
}
