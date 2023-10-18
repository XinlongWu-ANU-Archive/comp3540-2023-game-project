using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offset;

    public GameManager gameManager;

    public void Start()
    {

    }
    // Update is called once per frame
    public void Update()
    {
        if (gameManager.gameOver) // Check if the game is over based on the GameManager's variable
    {
            Destroy(gameObject);
            //Destroy(transform.parent.gameObject); // Destroy the parent GameObject, which includes the health bar
    }
    else
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
    }

    public void SetHealth(int health, int maxHealth){
        slider.value = health;
        slider.maxValue = maxHealth;
        slider.gameObject.SetActive(health < maxHealth);
        

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low,high, slider.normalizedValue);
    }
}
