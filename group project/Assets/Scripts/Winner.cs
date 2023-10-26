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
    public GameObject celebration;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        celebration.SetActive(false);
        winPanel.SetActive(false);
        allMonstersDestroyed = false;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

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
        celebration.SetActive(true);
        celebration.GetComponent<Celebration>().PlayAllParticleSystems();
        winPanel.SetActive(true);
        scoreText.text = GameManager.score.ToString();
        
        Destroy(playerController.gameObject);
    }
   
}

