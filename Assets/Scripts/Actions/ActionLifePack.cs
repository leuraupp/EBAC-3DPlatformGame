using Items;
using UnityEngine;

public class ActionLifePack : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.E;
    public SOInt soInt;

    private void Start() {
        soInt = ItemManager.Instance.GetItemByType(ItemType.LIFE_PACK).SOInt;
    }

    private void RecoverLife() {
        if (soInt.value > 0) {
            ItemManager.Instance.RemoveByType(ItemType.LIFE_PACK);
            Player.Instance.healthBase.ResetLife();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(keyCode)) {
            RecoverLife();
        }
    }
}
