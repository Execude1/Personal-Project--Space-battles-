using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[DefaultExecutionOrder(1000)]
public class GameUIManager : MonoBehaviour
{
    public static GameUIManager gameUIManager;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        gameUIManager = this;
    }

    void Start()    // вывод на интерфейсе игры имя игрока
    {
        DisplayScore();
        DisplayHealth();
    }

    public void DisplayScore() // вывод на интерфейс кол-во очков
    {
        scoreText.text = "Score: " + GameManager.gameManager.score;
    }

    public void DisplayHealth() // вывод на интерфейс кол-во здоровья
    {
        healthText.text = "Health: " + GameManager.gameManager.health;
    }
}
