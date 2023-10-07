using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float speed;
    public EnemyHealthBar hp;

    
    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = health;
        hp.SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    public void Update()
    {
    
    }

    public void TakeDamage(int hit)
    {
        health -= hit;
        hp.SetHealth(health, maxHealth); // Update health bar with the new health value
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
