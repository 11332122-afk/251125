using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }
    public void RestartGame() { StartGame(); }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
