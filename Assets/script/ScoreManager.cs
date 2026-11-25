using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    public int score = 0;

    void Awake()
    {
        Instance = this;
        score = 0;
    }
    void Start() { UpdateScore(); }

    public void AddScore(int points)
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.IsGameOver) return;
        score += points;
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
