using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticle : MonoBehaviour
{
    public float timeToDestroy;
    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
