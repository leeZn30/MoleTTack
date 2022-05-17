using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("게임 진행 관련")]
    public bool isGameStart;
    public float gameTime;

    [Header("Score")]
    [SerializeField] private int Score;

    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endPanel;

    private void Awake()
    {
        isGameStart = true;
        Score = 0;
    }

    private void Update()
    {
        scoreText.text = Score.ToString();
    }

    public void finishGame()
    {
        isGameStart = false;

        endPanel.transform.parent.gameObject.SetActive(true);
        endPanel.text = "Your Score\n" + Score;

        if (PlayerPrefs.GetInt("PlayerScore") < Score)
            PlayerPrefs.SetInt("PlayerScore", Score);
    }

    public void addScore(int score)
    {
        int sum = Score + score;

        if (Score >= 0 && sum >= 0)
            Score += score;
    }

    
}
