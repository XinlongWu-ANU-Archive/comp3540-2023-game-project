using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 5f;
    private float direction;
    public int damage =1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     // Check if the bullet collided with a "Monster" or "Bird" tagged object.
        if (collision.CompareTag("Monster"))
        {
            // Get the script component (assuming it has one) from the collided object.
            Enemy enemy = collision.GetComponent<Enemy>();

            // If the object has an "Enemy" script, deal damage to it.
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // Destroy the bullet.
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Terrain"))
        {
            // Destroy the bullet when it hits "Terrain."
            Destroy(gameObject);
        }
    }

    public float Direction
    {
        get { return direction; }
        set
        {
            direction = value;
        }
    }
}
