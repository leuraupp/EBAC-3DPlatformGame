using UnityEngine;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
    public Transform gunPosition;

    private GunBase currentGun;

    protected override void Init() {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
    }

    private void CreateGun() {
        currentGun = Instantiate(gunBase, gunPosition);

        currentGun.transform.localPosition = currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot() {
        currentGun.StartShoot();
    }

    private void CancelShoot() {
        currentGun.StopShoot();
    }
}
