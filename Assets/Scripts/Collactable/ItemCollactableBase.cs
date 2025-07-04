using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {
    public class ItemCollactableBase : MonoBehaviour {

        public SFXType sfxType;
        public ItemType itemType;
        public string compareTag = "Player";
        public ParticleSystem particleSystem;
        public float timeToDestroy = 2f;
        public GameObject graphicItem;
        public Collider collider;

        [Header("Sounds")]
        public AudioSource audioSource;

        private void Awake() {
            if (particleSystem != null) {
                particleSystem.transform.SetParent(null);
            }
        }

        private void PlaySFX() {
            SFXPool.Instance.Play(sfxType);
        }

        private void OnTriggerEnter(Collider collision) {
            if (collision.transform.CompareTag(compareTag)) {
                Collect();
            }
        }

        protected virtual void Collect() {
            PlaySFX();
            if (graphicItem != null) {
                graphicItem.SetActive(false);
            }
            Invoke(nameof(HideObject), timeToDestroy);
            OnCollect();
        }

        private void HideObject() {
            gameObject.SetActive(false);
        }

        protected virtual void OnCollect() {
            if (particleSystem != null) {
                particleSystem.Play();
            }
            if (audioSource != null) {
                audioSource.Play();
            }
            if (collider != null) {
                collider.enabled = false;
            }
            ItemManager.Instance.AddByType(itemType);
        }
    }
}