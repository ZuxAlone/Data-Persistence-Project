using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string BestName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [Serializable]
    class GameData
    {
        public string Name;
        public int Score;
    }

    public void SaveData()
    {
        GameData data = new GameData();
        data.Name = BestName;
        data.Score = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            BestName = data.Name;
            BestScore = data.Score;
        }
    }
}
