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
    [SerializeField] private TMP_Text bestScoreText;

    [SerializeField] private GameObject endScreenPlace;
    [SerializeField] private GameObject pauseMenuPlace;

    [SerializeField] private TMP_Text scoreTextEndScreen;
    [SerializeField] private TMP_Text bestScoreEndScreen;

    private bool isPause;

    void Awake()
    {
        gameUIManager = this;
    }

    void Start()    // ����� �� ���������� ���� ��� ������
    {
        isPause = false;

        DisplayBestScore();
        DisplayScore();
        DisplayHealth();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                Time.timeScale = 1;
                pauseMenuPlace.SetActive(false);
                isPause = false;
            }
            else
            {
                Time.timeScale = 0;
                pauseMenuPlace.SetActive(true);
                isPause = true;
            }
        }
    }

    public void DisplayScore() // ����� �� ��������� ���-�� �����
    {
        scoreText.text = "Score: " + GameManager.gameManager.score;
    }

    public void DisplayBestScore() // ����� �� ��������� ���-�� ������� �����
    {
        bestScoreText.text = "Best Score: " + GameManager.gameManager.bestScore;
    }

    public void DisplayHealth() // ����� �� ��������� ���-�� ��������
    {
        healthText.text = "Health: " + GameManager.gameManager.health;
    }

    public void GameOver()
    {
        ActiveEndScreen();
        endScreenPlace.transform.Find("GameOver Text").gameObject.SetActive(true);
    }

    public void VictoriousEnd()
    {
        ActiveEndScreen();
        endScreenPlace.transform.Find("YouWin Text").gameObject.SetActive(true);
    }

    void ActiveEndScreen()
    {
        Time.timeScale = 0;
        GameManager.gameManager.CheckSaveBestScore();
        endScreenPlace.SetActive(true);
        scoreTextEndScreen.text = scoreText.text;
        bestScoreEndScreen.text = $"Best Score: {GameManager.gameManager.bestScore}";
    }
}
