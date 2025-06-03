using UnityEngine;

namespace Enemy {
    public class EnemyShoot : EnemyBase {
        public GunBase gun;

        protected override void Init() {
            base.Init();

            gun.StartShoot();
        }
    }
}
