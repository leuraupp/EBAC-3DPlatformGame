using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Projectile Config")]
    public ProjectileBase prefabProjectile;

    public SFXType sfxType = SFXType.GUN;

    public Transform positionToShoot;
    public float timeBetweenShoots = .1f;
    public float speedProjectile = 50f;

    private Coroutine _currentCoroutine;

    protected virtual IEnumerator ShootCoroutine(UIFillUpdater uiGun) {
        while (true) {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    private void PlaySFX() {
        SFXPool.Instance.Play(sfxType);
    }

    public virtual void Shoot() {
        PlaySFX();
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speedProjectile;
    }

    public void StartShoot(UIFillUpdater uiGun) {
        StopShoot();
        _currentCoroutine = StartCoroutine(ShootCoroutine(uiGun));
    }

    public void StopShoot() {
        if (_currentCoroutine != null) {
            StopCoroutine(_currentCoroutine);
        }
    }
}
