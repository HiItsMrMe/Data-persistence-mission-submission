using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public int highscorePoints;
    public string highscorePlayer;

    private class SaveData
    {
        public int highscorePoints;
        public string highscorePlayer;
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            LoadHighscore();
            Debug.Log("loading highscore...");
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void LoadHighscore()
    {
        string json = File.ReadAllText(Application.persistentDataPath + "/highscore.json");

        Debug.Log(json);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        highscorePlayer = data.highscorePlayer;
        highscorePoints = data.highscorePoints;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highscorePoints = highscorePoints;
        data.highscorePlayer = highscorePlayer;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

}
