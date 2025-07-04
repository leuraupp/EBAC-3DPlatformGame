using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour {
    public KeyCode openKey = KeyCode.E;
    public Animator animator;
    public string openAnimationName = "Open";

    [Header("Notification Settings")]
    public GameObject notificationPrefab;
    public float notificationDuration = .2f;
    public Ease notificationEase = Ease.InOutBounce;

    [Header("Chest State")]
    public ChestItemBase chestItem;

    private float startScale;

    private bool isOpen = false;
    private bool isNotificationVisible = false;

    private void Start() {
        startScale = notificationPrefab.transform.localScale.x;
        notificationPrefab.transform.localScale = Vector3.zero;
    }

    [NaughtyAttributes.Button("Open Chest")]
    private void OpenChest() {
        if (isOpen) {
            return;
        }
        isOpen = true;

        animator.SetTrigger(openAnimationName);
        HideNotification();
        Invoke(nameof(ShowItem), 1f);
    }

    private void ShowItem() {
        chestItem.ShowItem();

        Invoke(nameof(CollectItem), 1f);
    }

    private void CollectItem() {
        chestItem.CollectItem();
    }

    private void OnTriggerEnter(Collider other) {
        Player p = other.gameObject.GetComponent<Player>();
        if (p != null) {
            ShowNotification();
        }
    }

    private void OnTriggerExit(Collider other) {
        HideNotification();
    }

    private void ShowNotification() {
        notificationPrefab.transform.localScale = Vector3.zero;
        notificationPrefab.transform.DOScale(startScale, notificationDuration).SetEase(notificationEase);
        isNotificationVisible = true;
    }

    private void HideNotification() {
        notificationPrefab.transform.DOScale(Vector3.zero, notificationDuration).SetEase(notificationEase);
        isNotificationVisible = false;
    }

    private void Update() {
        if (Input.GetKeyDown(openKey) && isNotificationVisible) {
            OpenChest();
        }
    }
}
