using DG.Tweening;
using UnityEngine;

public class FlashColor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public SkinnedMeshRenderer skinnedMeshRenderer;

    [Header("Flash Settings")]
    public Color flashColor = Color.red;
    public float flashDuration = 0.5f;

    private Color originalColor;

    private Tween currentTween;

    private void OnValidate() {
        if (meshRenderer == null) {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        if (skinnedMeshRenderer == null) {
            skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        }
    }

    [NaughtyAttributes.Button("Flash")]
    public void Flash() {
        if (meshRenderer != null &&  !currentTween.IsActive()) {
            currentTween = meshRenderer.material.DOColor(flashColor, "_EmissionColor", flashDuration).SetLoops(2, LoopType.Yoyo);
        }

        if (skinnedMeshRenderer != null && !currentTween.IsActive()) {
            currentTween = skinnedMeshRenderer.material.DOColor(flashColor, "_EmissionColor", flashDuration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
