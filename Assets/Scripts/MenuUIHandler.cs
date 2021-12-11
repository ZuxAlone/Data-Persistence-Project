using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI playerNameText;

    private void Start()
    {
        DataManager.Instance.LoadData();
        if (DataManager.Instance.BestScore != 0)
        {
            string name = DataManager.Instance.BestName;
            int score = DataManager.Instance.BestScore;
            bestScoreText.text = $"Best score by {name}: {score}";
        }
        else
        {
            bestScoreText.text = "No score set yet";
        }
    }

    public void StartGame()
    {
        DataManager.Instance.PlayerName = playerNameText.text;
        SceneManager.LoadScene(1);
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
