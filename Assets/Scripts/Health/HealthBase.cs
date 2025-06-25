using Animation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour, IDamageable
{
    public float startLife = 100f;
    public bool destroyOnKill = false;

    [SerializeField] private float currentLife;

    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;

    public List<UIFillUpdater> uiFills;

    private void Awake() {
        Init();
    }

    public void Init() {
        ResetLife();
    }

    public void ResetLife() {
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
        Damage(20);
    }

    public void Damage(float damage) {
        currentLife -= damage;
        if (currentLife <= 0) {
            Kill();
        }
        UpdateUI();
        OnDamage?.Invoke(this);
    }

    public void Damage(float damage, Vector3 dir) {
        Damage(damage);
    }

    private void UpdateUI() {
        if (uiFills != null) {
            uiFills.ForEach(u => u.UpdateValue((float) currentLife / startLife));
        }
    }
}
