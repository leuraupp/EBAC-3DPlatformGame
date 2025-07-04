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
    public void SavePlayerItemHealth(float itemHealth) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerItemHealth = itemHealth;
        Save();
    }
    public void SavePlayerHealth(float health) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.playerHealth = health;
        Save();
    }
    public void SaveLastCheckpoint(int checkpoint) {
        if (saveData == null) {
            CreateNewSave();
        }
        saveData.lastCheckpoint = checkpoint;
        Save();
    }

    public void Save() {
        string json = JsonUtility.ToJson(saveData);
        SaveFile(json);
    }
    #endregion

    #region Load
    public int LoadPlayerLevel() {
        if (saveData == null) {
            return 0;
        } else {
            return saveData.playerLevel;
        }
    }
    public float LoadPlayerCoins() {
        if (saveData == null) {
            return 0;
        } else {
            return saveData.playerCoins;
        }
    }
    public float LoadPlayerItemHealth() {
        if (saveData == null) {
            return 0;
        } else {
            return saveData.playerItemHealth;
        }
    }
    public float LoadPlayerHealth() {
        if (saveData == null) {
            return 100;
        } else {
            return saveData.playerHealth;
        }
    }
    public int LoadLastCheckpoint() {
        if (saveData == null) {
            return 0;
        } else {
            return saveData.lastCheckpoint;
        }
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

    public void CreateNewSave() {
        saveData = new SaveData {
            playerName = "Player",
            playerLevel = 1,
            playerCoins = 0f,
            playerItemHealth = 0f,
            playerHealth = 100f,
            lastCheckpoint = 0
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
    public float playerItemHealth;
    public float playerHealth;
    public int lastCheckpoint;
}
