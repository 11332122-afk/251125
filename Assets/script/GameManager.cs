using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TMP_Text gameOverText;
    public TMP_Text totalScoreText;
    public float returnDelay = 3f;
    private bool isGameOver = false;
    public bool IsGameOver { get { return isGameOver; } }

    void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        isGameOver = false;
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false);
        if (totalScoreText != null)
            totalScoreText.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        if (gameOverText != null)
        {
            gameOverText.text = "GameOver";
            gameOverText.gameObject.SetActive(true);
        }
        if (totalScoreText != null)
        {
            int finalScore = ScoreManager.Instance != null
                ? ScoreManager.Instance.score : 0;
            totalScoreText.text = "Total Score: " + finalScore;
            totalScoreText.gameObject.SetActive(true);
        }
        Time.timeScale = 0f;
        StartCoroutine(ReturnToMenu());
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSecondsRealtime(returnDelay);
        BackToMenu();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void StartGame() { RestartGame(); }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
