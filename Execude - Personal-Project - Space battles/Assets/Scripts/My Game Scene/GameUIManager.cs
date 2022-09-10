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

    void Start()    // ����� �� ���������� ���� ��� ������
    {
        DisplayScore();
        DisplayHealth();
    }

    public void DisplayScore() // ����� �� ��������� ���-�� �����
    {
        scoreText.text = "Score: " + GameManager.gameManager.score;
    }

    public void DisplayHealth() // ����� �� ��������� ���-�� ��������
    {
        healthText.text = "Health: " + GameManager.gameManager.health;
    }
}
