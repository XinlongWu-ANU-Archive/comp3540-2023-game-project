using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{ 
    public TextMeshProUGUI winnerText;
    public GameObject restartButton;
    public GameObject[] monsters;
    public GameObject winHint;
    bool allMonstersDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        winnerText.gameObject.SetActive(false);
        restartButton.SetActive(false);
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
        winnerText.gameObject.SetActive(true);
        Time.timeScale = 0f; // Pause the game
        restartButton.SetActive(true);
    }

  
   
}

