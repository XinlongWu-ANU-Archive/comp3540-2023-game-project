using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet bulletType;
    private PlayerController player;
    private float shootGap = 0.3f;
    private float shootTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= shootGap)
        {
            shoot();
            shootTimer = 0;
        }
    }

    void shoot()
    {
        Bullet bullet = Instantiate(bulletType, player.transform.position, Quaternion.identity).GetComponent<Bullet>();

        bullet.Direction = player.faceToRight ? 1f : -1f;
    }
}
