using DG.Tweening;
using System.Collections;
using UnityEngine;

public class DestructableItemBase : MonoBehaviour
{
    public HealthBase healthBase;

    public float shakeDuration = .1f;
    public int shakeForce = 1;

    [Header("Drop Config")]
    public int coinsToDrop = 0;
    public GameObject coinPrefab;
    public GameObject dropPosition;

    private void OnValidate() {
        if (healthBase == null) {
            healthBase = GetComponent<HealthBase>();
        }
    }

    private void Awake() {
        OnValidate();
        healthBase.OnDamage += OnDamage;
        healthBase.OnKill += OnKill;
    }

    private void OnDamage(HealthBase h) {
        transform.DOShakeScale(shakeDuration, Vector3.up, shakeForce);
    }

    [NaughtyAttributes.Button("Kill")]
    private void Kill() {
        OnKill(healthBase);
    }

    private void OnKill(HealthBase h) {
        if (coinsToDrop > 0 && coinPrefab != null && dropPosition != null) {
            StartCoroutine(DropOnDestroy());
        }
    }

    IEnumerator DropOnDestroy() {
        for (int i = 0; i < coinsToDrop; i++) {
            DropCoins();
            yield return new WaitForSeconds(0.02f);
        }
        Destroy(gameObject);
    }

    private void DropCoins() {
        var i = Instantiate(coinPrefab, dropPosition.transform.position, Quaternion.identity);
        i.transform.DOScale(0, .5f).SetEase(Ease.OutBack).From();
    }

}
