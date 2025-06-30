using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    public int amount = 5;
    public GameObject coinObject;

    [Header("Animation Settings")]
    public float duration = 0.2f;
    public float tweenEndTime = 0.5f;
    public Ease ease = Ease.OutBack;

    [Header("Range Position")]
    public Vector2 randomRange = new Vector2(1f, -1f);

    private List<GameObject> items = new List<GameObject>();

    public override void ShowItem() {
        base.ShowItem();
        CreateItem();
    }

    private void CreateItem() {
        for (int i = 0; i < amount; i++) {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x, randomRange.y);
            item.transform.DOScale(0, duration).SetEase(ease).From();
            items.Add(item);
        }
    }

    public override void CollectItem() {
        base.CollectItem();

        foreach (var item in items) {
            item.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            item.transform.DOScale(0, tweenEndTime /2).SetDelay(tweenEndTime / 2);
        }
    }
}
