using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBird : Enemy
{
    private Transform player;
    public float lineOfSite;
    public Transform startPoint;
    public LayerMask obstacleLayer; // Layer for obstacles
    public float obstacleDetectionDistance = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (player == null)
        {
            return;
        }

        if (IsPlayerInLineOfSight())
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }

        Flip();
    }

    private bool IsPlayerInLineOfSight()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        // Check if the player is within the line of sight and there are no obstacles in the way
        if (distanceFromPlayer < lineOfSite)
        {
            // Cast a ray to check for obstacles between the bird and the player
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, distanceFromPlayer, obstacleLayer);
            if (hit.collider == null)
            {
                return true;
            }
        }

        return false;
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);

        
    }
}
