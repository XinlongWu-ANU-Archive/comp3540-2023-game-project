using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public float speed;
    public EnemyHealthBar hp;
    public SpriteRenderer sr;
    private Color originalColor;
    public float flashTime =0.5f;
    public GameObject DeathParticle;

    // Start is called before the first frame update
    public void Start()
    {
        maxHealth = health;
        hp.SetHealth(health, maxHealth);
        sr = GetComponent<SpriteRenderer>(); // Corrected GetComponent method
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {

    }

    public void TakeDamage(int hit)
    {
        health -= hit;
        hp.SetHealth(health, maxHealth);
        StartCoroutine(Flash(flashTime)); // Use StartCoroutine to handle timing

        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(DeathParticle,transform.position,Quaternion.identity);
        }
    }

    IEnumerator Flash(float time)
    {
        sr.color = Color.red; // Changed Color.Red to Color.red
        yield return new WaitForSeconds(time);
        ResetColor();
    }

    void ResetColor()
    {
        sr.color = originalColor;
    }
}


