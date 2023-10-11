using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesHorizontalMover : MonoBehaviour
{
    public float speed = 1f;
    public GameObject leftTerrain;
    public GameObject rightTerrain;

    private Rigidbody2D rb;
    private bool movingRight = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Set the object's velocity
        float horizontalSpeed = movingRight ? speed : -speed;
        rb.velocity = new Vector2(horizontalSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for colliding objects and change the movement direction.
        if (collision.gameObject == leftTerrain)
        {
            movingRight = true; // Collide with leftTerrain, and start moving to the right
        }
        else if (collision.gameObject == rightTerrain)
        {
            movingRight = false; // Collide with rightTerrain, and start moving to the left
        }
    }
}
