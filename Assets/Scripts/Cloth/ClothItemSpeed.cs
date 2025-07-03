using UnityEngine;


namespace Cloth {
    public class ClothItemSpeed : ClothItemBase {

        public float targetSpeed = 2f;

        public override void Collect() {
            base.Collect();
            Player.Instance.ChangeSpeed(targetSpeed, duration);
        }
    }
}