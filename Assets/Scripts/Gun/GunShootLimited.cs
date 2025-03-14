using System.Collections;
using UnityEngine;

public class GunShootLimited : GunBase {
    public float maxShoot = 5f;
    public float timeToReload = 2f;

    private float currentShoot = 0f;
    private bool isReloading = false;

    protected override IEnumerator ShootCoroutine() {
        if (isReloading) {
            yield break;
        }

        while (currentShoot < maxShoot) {
            Shoot();
            currentShoot++;
            CheckNeedToReload();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    private void CheckNeedToReload() {
        if (currentShoot >= maxShoot) {
            isReloading = true;
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload() {
        yield return new WaitForSeconds(timeToReload);
        currentShoot = 0;
        isReloading = false;
    }
}
