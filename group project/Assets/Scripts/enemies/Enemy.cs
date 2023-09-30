using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(health<=0){
            Destroy(gameObject);
        }
    }

    public void takeDamage (int hit){
        health -= hit;
    }
}
