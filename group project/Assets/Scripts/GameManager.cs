using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int life;
    public GameObject[] hearts;
    public GameOverUI gameOverUI;
    private bool gameOver;
    private bool isPaused;

    public GameObject resumeButton;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLife()
    {
        life--;
        if (life == 2)
        {
            hearts[2].SetActive(false);
        }
        if (life == 1)
        {
            hearts[1].SetActive(false);
        }
        if (life == 0)
        {
            hearts[0].SetActive(false);
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOver = true;
        pauseButton.SetActive(false);
        gameOverUI.ShowGameOverUI(score);
    }


    public void PauseGame()
    {
        isPaused = true;
        pauseButton.SetActive(false);
        
        resumeButton.SetActive(true);

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;
        resumeButton.SetActive(false);
        Time.timeScale = 1;
        pauseButton.SetActive(true);

    }

    public void StartGame()
    {
        gameOver = false;
        isPaused = false;
        Time.timeScale = 1;
        score = 0;
        life = 3;
        scoreText.text = "Score: " + score;

    }

    public void RestartGame()
    {
        StartGame();
        SceneManager.LoadScene("Level0");
    }

}
