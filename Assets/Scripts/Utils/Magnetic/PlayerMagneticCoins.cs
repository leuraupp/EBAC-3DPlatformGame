using UnityEngine;
using Items;

public class PlayerMagneticCoins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        ItemCollactableBase i = other.GetComponent<ItemCollactableBase>();
        if (i != null) {
            i.gameObject.AddComponent<Magnetic>();
        }
    }
}
