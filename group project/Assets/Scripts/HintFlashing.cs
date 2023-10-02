using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintFlashing : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float step = -1;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = spriteRenderer.color;
        color.a += step * Time.deltaTime;
        if (color.a > 1.5 || color.a < 0)
            step = -step;
        spriteRenderer.color = color;
    }
}
