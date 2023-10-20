using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public static int score = 0;
    private static int life = 3;
    public GameObject[] hearts;
    public GameOverUI gameOverUI;
    public bool gameOver;
    public bool isPaused;
    public bool isLevel0 = false;
    public GameObject startPagePanel;
    public GameObject resumeButton;
    public GameObject pauseButton;


    // Start is called before the first frame update
    void Start()
    {
        //playBGM = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name=="Level0")
        {
            Time.timeScale = 0;
            pauseButton.SetActive(false);
        }
        else {
            StartGame();
        }
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

    

    // update life hearts when the player loses one life
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

    public void ShowLife()
    {
        if (life == 3)
        {
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (life == 2)
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (life == 1)
        {
            hearts[2].SetActive(false);
            hearts[1].SetActive(false);
            hearts[0].SetActive(true);
        }
        else {
            life = 3;
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
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
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound, 0.1f);
        isPaused = true;
        pauseButton.SetActive(false);
        
        resumeButton.SetActive(true);

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound, 0.1f);
        isPaused = false;
        resumeButton.SetActive(false);
        Time.timeScale = 1;
        pauseButton.SetActive(true);

    }

    public void StartGame()
    {
        gameOver = false;
        isPaused = false;
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "Level0")
        {
            Time.timeScale = 0;
            score = 0;
            life = 3;
        }
            
        ShowLife();
        scoreText.text = "Score: " + score;

    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("Level0");
        //score = 0;
        //life = 3;
    }

}
