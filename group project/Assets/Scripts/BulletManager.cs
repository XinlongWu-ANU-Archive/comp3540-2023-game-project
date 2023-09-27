using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet bulletType;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            shoot();
    }

    void shoot()
    {
        Bullet bullet = Instantiate(bulletType, player.transform.position, new Quaternion()).GetComponent<Bullet>();
        bullet.Direction = player.faceToRight ? 1f : -1f;
    }
}
