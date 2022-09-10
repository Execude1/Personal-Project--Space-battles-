using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameUIManager gameUIManager;
    public static GameManager gameManager;
    public bool isGameActive = true;
    public int score;
    public int health;

    void Start()
    {
        gameManager = this;
        AddScore(0);
        AddHealth(100);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        gameUIManager.DisplayScore();
    }

    public void SubHealth(int subHealth)
    {
        health -= subHealth;
        gameUIManager.DisplayHealth();

        if(health <= 0)
        {
            Time.timeScale = 0;
        }
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
}
