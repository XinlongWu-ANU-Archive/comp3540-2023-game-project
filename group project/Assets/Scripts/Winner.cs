using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{ 
    public GameObject[] monsters;
    public GameObject winHint;
    public GameObject winPanel;
    public Text scoreText;
    public GameManager gameManager;
    bool allMonstersDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);
        allMonstersDestroyed = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!allMonstersDestroyed) {
            checkWin();
        }
        
    }

    // Check if all monsters have been destroyed, if destroyed then show win hint.
    void checkWin()
    {
        allMonstersDestroyed = true;
        foreach (GameObject monster in monsters)
        {
            if (monster != null)
            {
                allMonstersDestroyed = false;
                break;
            }
        }
        if (allMonstersDestroyed)
        {
            winHint.SetActive(true);
            SoundManager.instance.PlaySound(SoundManager.instance.gateOpenSound, 0.2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && allMonstersDestroyed)
        {
            Win();
        }
    }

    private void Win()
    {
        winPanel.SetActive(true);
        scoreText.text = GameManager.score.ToString();
        Time.timeScale = 0f; // Pause the game
    }

  
   
}

