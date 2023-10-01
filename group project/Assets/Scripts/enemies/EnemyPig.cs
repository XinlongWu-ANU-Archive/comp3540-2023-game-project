using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPig : Enemy
{
    public Transform leftWaypoint;   // Leftmost patrol position
    public Transform rightWaypoint;  // Rightmost patrol position

    private bool movingRight = true; // Flag to track movement direction

    private Transform targetWaypoint; // Current target waypoint

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the starting position and direction
        transform.position = leftWaypoint.position;
        targetWaypoint = leftWaypoint; // Start by moving to the right

        // Get a reference to the SpriteRenderer component
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        // Calculate the direction vector to the target waypoint
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;

        // Calculate the new position using the direction vector and speed
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

        // Move to the new position
        transform.position = newPosition;

        // Check if the enemy has reached the target waypoint
        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Change direction by switching target waypoint
            if (movingRight)
            {
                targetWaypoint = rightWaypoint;
                spriteRenderer.flipX = true; // Flip sprite to face left
            }
            else
            {
                targetWaypoint = leftWaypoint;
                spriteRenderer.flipX = false; // Flip sprite to face right
            }
            movingRight = !movingRight;
        }
    }
}