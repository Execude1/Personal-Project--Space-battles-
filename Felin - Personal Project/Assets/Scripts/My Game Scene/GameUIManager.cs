using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text playerName;

    void Start()
    {
        playerName.text = "Player: " + GameUIHandler.titleScene.namePlayer;
    }
}
