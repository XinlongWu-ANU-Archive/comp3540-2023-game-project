using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celebration : MonoBehaviour
{
    public ParticleSystem[] celebrationParticles;
    // Start is called before the first frame update
    void Start()
    {
        StopAllParticleSystems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAllParticleSystems()
    {
        for (int i = 0; i < celebrationParticles.Length; i++)
        {
            if (celebrationParticles[i] != null)
            {
                celebrationParticles[i].Play();
            }
        }
    }

    public void StopAllParticleSystems()
    {
        for (int i = 0; i < celebrationParticles.Length; i++)
        {
            if (celebrationParticles[i] != null)
            {
                celebrationParticles[i].Stop();
            }
        }
    }

}
