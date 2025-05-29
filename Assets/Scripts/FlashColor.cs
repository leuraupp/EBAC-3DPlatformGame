using DG.Tweening;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    [Header("Flash Settings")]
    public Color flashColor = Color.red;
    public float flashDuration = 0.5f;

    private Color originalColor;

    private Tween currentTween;

    private void Start() {
        originalColor = meshRenderer.material.GetColor("_EmissionColor");
    }

    [NaughtyAttributes.Button("Flash")]
    public void Flash() {
        if (!currentTween.IsActive()) {
            currentTween = meshRenderer.material.DOColor(flashColor, "_EmissionColor", flashDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
