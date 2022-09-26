using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameUIManager gameUIManager;
    public static GameManager gameManager;
    public bool isGameActive = true;
    public int score;
    public int bestScore;
    public int health;

    void Start()
    {
        gameManager = this;

        bestScore = 0;
        AddScore(0);
        AddHealth(100);

        LoadBestScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int bestScore;
    }

    void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScore = data.bestScore;
        }

        gameUIManager.DisplayBestScore();
    }

    public void CheckSaveBestScore()
    {
        if(score > bestScore)
        {
            bestScore = score;
        }

        SaveScore();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        gameUIManager.DisplayScore();
    }

    public void SubHealth(int subHealth)
    {
        health -= subHealth;
        
        if(health <= 0)
        {
            health = 0;
            gameUIManager.GameOver();
        }

        gameUIManager.DisplayHealth();
    }

    public void AddHealth(int addHealth)
    {
        health += addHealth;
       
        if (health > 100)
        {
            health = 100;
        }

        gameUIManager.DisplayHealth();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
