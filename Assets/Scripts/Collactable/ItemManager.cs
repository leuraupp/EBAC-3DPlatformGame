using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

namespace Items {
    public enum ItemType {
        COIN,
        LIFE_PACK
    }

    public class ItemManager : Singleton<ItemManager> {
        public List<ItemSetup> itemSetups;

        private void Start() {
            OnReset();
            Invoke(nameof(LoadItems), 0.1f);
        }

        private void OnReset() {
            itemSetups.ForEach(i => i.SOInt.value = 0);
        }

        public void AddByType(ItemType itemType, int amount = 1) {
            itemSetups.Find(i => i.itemType == itemType).SOInt.value += amount;

            if (itemType == ItemType.COIN)
                SaveManager.Instance.SavePlayerCoins(itemSetups.Find(i => i.itemType == ItemType.COIN).SOInt.value);
            else if (itemType == ItemType.LIFE_PACK)
                SaveManager.Instance.SavePlayerHealth(itemSetups.Find(i => i.itemType == ItemType.LIFE_PACK).SOInt.value);
        }

        public ItemSetup GetItemByType(ItemType itemType, int amount = 1) {
            return itemSetups.Find(i => i.itemType == itemType);
        }

        public void RemoveByType(ItemType itemType, int amount = 1) {
            if (amount <= 0) return;

            var item = itemSetups.Find(i => i.itemType == itemType);
            item.SOInt.value -= amount;

            if (item.SOInt.value < 0) {
                item.SOInt.value = 0;
            }
        }

        public void LoadItems() {
            Debug.Log("Loading items from SaveManager");
            Debug.Log($"Coins: {SaveManager.Instance}");
            AddByType(ItemType.COIN, (int)SaveManager.Instance.LoadPlayerCoins());
            AddByType(ItemType.LIFE_PACK, (int)SaveManager.Instance.LoadPlayerHealth());
        }
    }

    [System.Serializable]
    public class ItemSetup {
        public ItemType itemType;
        public SOInt SOInt;
        public Sprite icon;
    }
}
