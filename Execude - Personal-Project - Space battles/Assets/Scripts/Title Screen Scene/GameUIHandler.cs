using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
    using UnityEditor;
#endif

public class GameUIHandler : MonoBehaviour
{
    public static GameUIHandler titleScene { get; private set; }
    public string namePlayer { get; private set; }
    [SerializeField] private TMP_InputField inputName;

    void Awake()
    {
        titleScene = this;
        DontDestroyOnLoad(titleScene);
    }

    public void StartGame()
    {
        namePlayer = inputName.text;

        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
    EditorApplication.ExitPlaymode();
#else
    Application.Quit();
#endif
    }
}
