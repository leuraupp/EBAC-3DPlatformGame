using Ebac.Core.Singleton;
using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager> {
    private SaveData saveData;
    private string path = Application.dataPath + "/savefile.json";

    private void Start() {
        Load();
        Debug.Log("SaveManager started and loaded save data.");
        Debug.Log($"Player Name: {saveData.playerName}");
        Debug.Log($"Player Level: {saveData.playerLevel}");
        Debug.Log($"Player Coins: {saveData.playerCoins}");
        Debug.Log($"Player Health: {saveData.playerHealth}");
    }

    #region Save
    public void SaveLastLevel(int level) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerLevel = level;
        Save();
    }

    public void SavePlayerName(string name) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerName = name;
        Save();
    }
    public void SavePlayerCoins(float coins) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerCoins = coins;
        Save();
    }
    public void SavePlayerHealth(float health) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerHealth = health;
        Save();
    }

    public void Save() {
        string json = JsonUtility.ToJson(saveData);
        SaveFile(json);
    }
    #endregion

    #region Load
    public int LoadPlayerLevel() {
        return saveData.playerLevel;
    }
    public float LoadPlayerCoins() {
        return saveData.playerCoins;
    }
    public float LoadPlayerHealth() {
        return saveData.playerHealth;
    }

    public void Load() {
        string fileToLoad = "";
        if (File.Exists(path)) {
            fileToLoad = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(fileToLoad);
        } else {
            CreateNewSave();
            Save();
        }
    }
    #endregion

    private void CreateNewSave() {
        saveData = new SaveData {
            playerName = "Player",
            playerLevel = 1,
            playerCoins = 0f,
            playerHealth = 100f
        };
    }

    public void SaveFile(string json) {
        File.WriteAllText(path, json);
    }
}

[System.Serializable]
public class SaveData
{
    public string playerName;
    public int playerLevel;
    public float playerCoins;
    public float playerHealth;
}
