using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIFillUpdater : MonoBehaviour
{
    public Image uiImage;

    [Header("Animation")]
    public float duration = .1f;
    public Ease ease = Ease.Linear;

    private Tween currTween;

    private void OnValidate() {
        if (uiImage == null) {
            uiImage = GetComponent<Image>();
        }
    }

    public void UpdateValue(float value) {
        uiImage.fillAmount = value;
    }

    public void UpdateValue(float value, float maxValue) {
        if (currTween != null) {
            currTween.Kill();
        }
        currTween = uiImage.DOFillAmount(1 - (value / maxValue), duration).SetEase(ease);
    }
}
