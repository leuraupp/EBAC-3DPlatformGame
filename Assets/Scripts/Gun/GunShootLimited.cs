using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShootLimited : GunBase {

    public List<UIFillUpdater> uiGunUpdaters;

    public float maxShoot = 5f;
    public float timeToReload = 2f;

    private float currentShoot = 0f;
    private bool isReloading = false;

    private void Awake() {
        GetAllUIs();
    }

    protected override IEnumerator ShootCoroutine() {
        if (isReloading) {
            yield break;
        }

        while (currentShoot < maxShoot) {
            Shoot();
            currentShoot++;
            CheckNeedToReload();
            UpdateUI();
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
        float time = 0;
        while (time < timeToReload) {
            time += Time.deltaTime;
            foreach (var uiGunUpdater in uiGunUpdaters) {
                uiGunUpdater.UpdateValue(time/timeToReload);
            }
            yield return new WaitForEndOfFrame();
        }
        currentShoot = 0;
        isReloading = false;
    }

    private void UpdateUI() {
        foreach (var uiGunUpdater in uiGunUpdaters) {
            uiGunUpdater.UpdateValue(currentShoot, maxShoot);
        }
    }

    private void GetAllUIs() {
        uiGunUpdaters = GameObject.FindObjectsOfType<UIFillUpdater>().ToList();
    }
}
