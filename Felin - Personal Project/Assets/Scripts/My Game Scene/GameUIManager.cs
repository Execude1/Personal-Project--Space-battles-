using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    public static GameUIManager gameUIManager;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private TMP_Text playerName;
    [SerializeField] private TMP_Text scoreText;

    void Awake()
    {
        gameUIManager = this;
    }

    void Start()    // вывод на интерфейсе игры имя игрока
    {
        playerName.text = "Player: " + GameUIHandler.titleScene.namePlayer;
        DisplayScore();
    }

    public void DisplayScore() // вывод на интерфейс кол-во очков
    {
        scoreText.text = "Score: " + gameManager.Score;
    }
}
