using Ebac.Core.Singleton;
using UnityEngine;

public class LoadSceneManager : Singleton<LoadSceneManager> {
    public int sceneIndex = 0;

    public void LoadScene(string sceneName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(int sceneIndex) {
        this.sceneIndex = sceneIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
    }
    public void LoadSceneFromSaveFile() {
        sceneIndex = SaveManager.Instance.LoadPlayerLevel();
        Debug.Log($"Loading scene from save file with index: {sceneIndex}");
        LoadScene(sceneIndex);
    }
}
