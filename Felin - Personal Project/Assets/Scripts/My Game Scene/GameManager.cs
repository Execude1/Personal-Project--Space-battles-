using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameUIManager gameUIManager;

    private float m_score;
    public float Score
    {
        get
        {
            return m_score;
        }

        set
        {
            if(value >= 0)
            {
                m_score = value;
            }
        }
    }

    void Start()
    {
        AddScore(0);
    }

    void Update()
    {
        
    }

    public void AddScore(float addScore)
    {
        Score += addScore;
        gameUIManager.DisplayScore();
    }
}
