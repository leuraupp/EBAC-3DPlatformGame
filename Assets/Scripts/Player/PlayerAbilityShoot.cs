using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public List<GunBase> gunBases;
    public Transform gunPosition;

    private GunBase currentGun;

    protected override void Init() {
        base.Init();

        CreateGun(0);

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
        inputs.Gameplay.ChooseWeapon1.performed += ctx => ChangeGun(0);
        inputs.Gameplay.ChooseWeapon2.performed += ctx => ChangeGun(1);
        inputs.Gameplay.ChooseWeapon3.performed += ctx => ChangeGun(2);

    }

    private void CreateGun(int i) {
        if (gunBases[i] == null) {
            return;
        }
        currentGun = Instantiate(gunBases[i], gunPosition);

        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot() {
        currentGun.StartShoot();
    }

    private void CancelShoot() {
        currentGun.StopShoot();
    }

    private void ChangeGun(int index) {
        currentGun.StopShoot();
        Destroy(currentGun.gameObject);
        CreateGun(index);
    }
}
