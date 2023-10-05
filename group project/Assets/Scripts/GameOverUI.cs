using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverUI(int finalScore)
    {
        // Pause the game
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        scoreText.text = finalScore.ToString();
    }

    public void Retry()
    {
        //Time.timeScale = 1;
        SceneManager.LoadScene("Level0");
    }
}
