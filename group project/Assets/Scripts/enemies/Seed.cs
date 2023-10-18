using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public float seedSpeed = 2.5f; // Adjust the speed as needed
    public float seedLife = 2.0f;
    private Rigidbody2D rb;
    private Transform player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player != null)
        {
            // Calculate the direction to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Set the initial velocity of the seed based on the player's position
            rb.velocity = new Vector2((player.position.x > transform.position.x) ? seedSpeed : -seedSpeed, 0);
        }
    }

    void Update()
    {
       seedLife -= Time.deltaTime;

        // Check if the seed's lifetime has expired, and destroy it if it has
        if (seedLife <= 0)
        {
            Destroy(gameObject);
        }
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the seed when it hits the player
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bullet")){
            Destroy(gameObject);
        }
    }
}

