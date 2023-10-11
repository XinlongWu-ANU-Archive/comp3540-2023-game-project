using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0PlayerController : PlayerController
{
    private bool isShowing;
    private float showTimer;
    private float maxShowTime = 4.5f;
    private BulletManager bulletManager;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        bulletManager = GameObject.Find("BulletManager").GetComponent<BulletManager>();
        isShowing = true;
        gameManager.isLevel0 = true;
        horizontalInput = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
            showTimer += Time.deltaTime;
            if (showTimer >= maxShowTime)
            {
                isShowing = false;
                bulletManager.shoot();
            }
            return;
        }
        else
            base.Update();
    }
}
