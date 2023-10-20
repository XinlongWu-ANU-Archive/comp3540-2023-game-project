using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject gameOverPanel;
    public GameObject startPagePanel;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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

    public void Play()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonSound, 0.1f);
        startPagePanel.SetActive(false);
        gameManager.StartGame();
        Time.timeScale = 1;
    }
}
