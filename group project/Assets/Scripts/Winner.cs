using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{ 
    public TextMeshProUGUI winnerText;
    public GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        winnerText.gameObject.SetActive(false);
        restartButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

