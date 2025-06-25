using UnityEngine;

public class CheckpointsBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 01;

    private string checkpointKey = "CheckpointKey";

    private void Awake() {
        PlayerPrefs.SetInt(checkpointKey, 0);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Player") {
            CheckCheckpoints();
        }
    }

    private void CheckCheckpoints() {
        if (PlayerPrefs.GetInt(checkpointKey, 0) < key) {
            SaveCheckpoint();
            TurnOn();
        }
    }

    private void TurnOn() {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void TurnOff() {
        meshRenderer.material.SetColor("_EmissionColor", Color.grey);
    }

    private void SaveCheckpoint() {
        //PlayerPrefs.SetInt(checkpointKey, key);
        //PlayerPrefs.Save();

        CheckpointsManager.Instance.SaveCheckpoint(key);
    }
}
