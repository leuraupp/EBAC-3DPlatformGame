using UnityEngine;
using Ebac.Core.Singleton;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;

public class CheckpointsManager : Singleton<CheckpointsManager> {
    
    public int lastCheckpoint = 0;

    public List<CheckpointsBase> checkpoints;
    public TextMeshProUGUI checkpointText;

    private Color originalColor;

    private void Start() {
        originalColor = checkpointText.color;
        LoadLastCheckpoint();
    }

    public void SaveCheckpoint(int i) {
        if (i > lastCheckpoint) {
            lastCheckpoint = i;
            checkpointText.DOColor(new Color(originalColor.r, originalColor.g, originalColor.b, 1f), 0.1f);
            Invoke(nameof(HideMessage), 2f);
            SaveManager.Instance.SaveLastCheckpoint(lastCheckpoint);
        }
    }

    private void HideMessage() {
        checkpointText.DOColor(new Color(originalColor.r, originalColor.g, originalColor.b, 0f), 1f);
    }

    public bool HasCheckpoint() {
        return lastCheckpoint > 0;
    }

    public Vector3 GetPositionFromLastCheckpoint() {
        var checkpoint = checkpoints.Find(x => x.key == lastCheckpoint);

        return checkpoint != null ? checkpoint.transform.position : Vector3.zero;
    }

    public void LoadLastCheckpoint() {
        if (SaveManager.Instance != null && SaveManager.Instance.LoadLastCheckpoint() > 0) {
            lastCheckpoint = SaveManager.Instance.LoadLastCheckpoint();
            GetPositionFromLastCheckpoint();
        }
    }
}
