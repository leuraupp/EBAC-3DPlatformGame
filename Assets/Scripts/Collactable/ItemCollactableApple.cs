using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Items {
    public class ItemCollactableApple : ItemCollactableBase {
        public Collider2D collider;

        protected override void Collect() {
            base.Collect();
            //gameObject.transform.DOScaleX(-1, .3f).SetLoops(2, LoopType.Yoyo).OnComplete(() => Destroy(gameObject));
        }

        protected override void OnCollect() {
            base.OnCollect();
            ItemManager.Instance.AddByType(ItemType.COIN, 1);
            Destroy(gameObject);
            collider.enabled = false;
        }
    }
}
