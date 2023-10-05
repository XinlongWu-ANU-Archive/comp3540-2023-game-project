using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int life;
    public GameObject[] hearts;
    private bool gameOver;
    public bool isPaused;

    public GameObject resumeButton;
    public GameObject pauseButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isPaused = false;
        score = 0;
        life = 3;
        scoreText.text = "Score: " + score;
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
        if (life == 2) {
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

    private void GameOver() {
        gameOver = true;
        Debug.Log("Game Over!");
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



}
