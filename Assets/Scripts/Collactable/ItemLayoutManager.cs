using System.Collections.Generic;
using UnityEngine;

namespace Items {

    public class ItemLayoutManager : MonoBehaviour {
        public ItemLayout itemLayoutPrefab;
        public Transform container;

        public List<ItemLayout> itemLayouts;

        private void Start() {
            itemLayouts = new List<ItemLayout>();
            CreateItem();
        }

        private void CreateItem() {
            foreach (var setup in ItemManager.Instance.itemSetups) {
                var item = Instantiate(itemLayoutPrefab, container);
                item.Load(setup);
                itemLayouts.Add(item);
            }
        }
    }
}