using Animation;
using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    public float startLife = 100f;
    public bool destroyOnKill = false;

    [SerializeField] private float currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    private void Awake() {
        Init();
    }

    public void Init() {
        ResetLife();
    }

    protected void ResetLife() {
        currentLife = startLife;
    }

    protected virtual void Kill() {
        if (destroyOnKill) {
            Destroy(gameObject, 3f);
        }
        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage() {
        Damage(5);
    }

    public void Damage(float damage) {
        currentLife -= damage;
        if (currentLife <= 0) {
            Kill();
        }
        OnDamage?.Invoke(this);
    }
}
