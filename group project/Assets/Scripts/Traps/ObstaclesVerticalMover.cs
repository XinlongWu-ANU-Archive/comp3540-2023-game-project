using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesVerticalMover : MonoBehaviour
{
    public float speed = 1f;
    public GameObject beginTerrain;
    public GameObject endTerrain;

    private Rigidbody2D rb;
    private bool movingUp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // set the object's speed
        float verticalSpeed = movingUp ? speed : -speed;
        rb.velocity = new Vector2(0, verticalSpeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // checking colliding objects and changing the direction of movement
        if (collision.gameObject == beginTerrain)
        {
            movingUp = false; // start to move down
        }
        else if (collision.gameObject == endTerrain)
        {
            movingUp = true; // start to move up
        }
    }
}