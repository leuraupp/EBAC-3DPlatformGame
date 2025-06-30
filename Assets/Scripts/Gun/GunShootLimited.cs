using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimited : GunBase {

    public float maxShoot = 5f;
    public float timeToReload = 2f;

    private float currentShoot = 0f;
    private bool isReloading = false;

    protected override IEnumerator ShootCoroutine(UIFillUpdater uiGun) {
        if (isReloading) {
            yield break;
        }

        while (currentShoot < maxShoot) {
            Shoot();
            currentShoot++;
            CheckNeedToReload(uiGun);
            UpdateUI(uiGun);
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    private void CheckNeedToReload(UIFillUpdater uiGun) {
        if (currentShoot >= maxShoot) {
            isReloading = true;
            StartCoroutine(Reload(uiGun));
        }
    }

    private IEnumerator Reload(UIFillUpdater uiGun) {
        float time = 0;
        while (time < timeToReload) {
            time += Time.deltaTime;
            //foreach (var uiGunUpdater in uiGunUpdaters) {
            uiGun.UpdateValue(time/timeToReload);
            //}
            yield return new WaitForEndOfFrame();
        }
        currentShoot = 0;
        isReloading = false;
    }

    private void UpdateUI(UIFillUpdater uiGun) {
        //foreach (var uiGunUpdater in uiGunUpdaters) {
        Debug.Log($"Update UI: {uiGun}");
        uiGun.UpdateValue(currentShoot, maxShoot);
        //}
    }
}
