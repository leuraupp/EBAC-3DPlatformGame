using UnityEngine;


namespace Cloth {
    public class ClothItemGravity : ClothItemBase {

        public float targetGravity = 2f;
        public float jumpForce = 5f;

        public override void Collect() {
            base.Collect();
            Player.Instance.ChangeGravity(targetGravity, jumpForce, duration);
        }
    }
}
