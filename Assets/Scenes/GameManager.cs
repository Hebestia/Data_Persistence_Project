using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
    public string curUser;
    public string curHighUser = null;
    public int curHighScore;
    public TextMeshProUGUI inputName;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;

        DontDestroyOnLoad(this.gameObject);

        LoadScoreData();

        if (curHighUser == null)
            curHighUser = curUser;

    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnNameEnter()
    {
        curUser = inputName.text;
    }

    public void OnQuitButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    public void SaveScoreData(int newHighScore)
    {
        SaveData data = new SaveData();
        data.highScorePlayer = curUser;
        data.highScore = newHighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            curHighUser = data.highScorePlayer;
            curHighScore = data.highScore;
        }
    }
}
