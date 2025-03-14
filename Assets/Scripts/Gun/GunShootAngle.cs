using UnityEngine;

public class GunShootAngle : GunShootLimited
{
    public int amountOfProjectiles = 4;
    public float angleBetweenProjectiles = 10f;


    public override void Shoot() {
        int multiplier = 0;

        for (int i = 0; i < amountOfProjectiles; i++) {

            if (i % 2 == 0) {
                multiplier++;
            }

            var projectile = Instantiate(prefabProjectile, positionToShoot);
            projectile.transform.localPosition = Vector3.zero;
            projectile.transform.localEulerAngles = Vector3.zero + Vector3.up * (i%2 == 0 ? angleBetweenProjectiles : -angleBetweenProjectiles) * multiplier;
            projectile.speed = speedProjectile;
            projectile.transform.parent = null;

        }
    }
}
