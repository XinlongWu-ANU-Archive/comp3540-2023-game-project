using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private GameManager gameManager;
    private int scoreToAdd = 5;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Destroy fruits once the player touch them. And add 5 score per fruilt.
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(SoundManager.instance.fruitSound, 0.2f);
            Destroy(gameObject);
            gameManager.UpdateScore(scoreToAdd);
        }
    }
}
