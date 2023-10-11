using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrunk : Enemy
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        anim.GetComponent<Animator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    
}
