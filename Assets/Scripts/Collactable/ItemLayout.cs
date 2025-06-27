using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Items {
    public class ItemLayout : MonoBehaviour {
        private ItemSetup itemSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        public GameObject howToUseText;

        public void Load(ItemSetup setup) {
            itemSetup = setup;
            UpdateUi();
        }

        private void UpdateUi() {
            uiIcon.sprite = itemSetup.icon;
            if (itemSetup.itemType == ItemType.LIFE_PACK) {
                howToUseText.SetActive(true);
            } else {
                howToUseText.SetActive(false);
            }
        }

        private void Update() {
            uiValue.text = itemSetup.SOInt.value.ToString();
        }
    }
}