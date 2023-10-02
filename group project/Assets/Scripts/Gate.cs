using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject[] monsters;
    public GameObject hint;

    bool allMonstersDestroyed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkGate();
    }

    // Open gate and enable gate hint once all monsters are destroyed
    void checkGate() {
        bool allMonstersDestroyed = true;
        foreach (GameObject monster in monsters)
        {
            if (monster != null)
            {
                allMonstersDestroyed = false;
                break;
            }
        }
        if (allMonstersDestroyed)
        {
            gameObject.SetActive(false);
            if (hint != null)
                hint.SetActive(true);
        }
    }
}
