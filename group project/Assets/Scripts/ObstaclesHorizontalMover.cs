using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesHorizontalMover : MonoBehaviour
{
    public float speed = 1f;
    public GameObject leftTerrain;
    public GameObject rightTerrain;

    private Rigidbody2D rb;
    private bool movingRight = true; // 表示物体当前是否正在向右移动

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 设置物体的速度
        float horizontalSpeed = movingRight ? speed : -speed;
        rb.velocity = new Vector2(horizontalSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 检查碰撞的对象并改变移动方向
        if (collision.gameObject == leftTerrain)
        {
            movingRight = true; // 与leftTerrain碰撞，开始向右移动
        }
        else if (collision.gameObject == rightTerrain)
        {
            movingRight = false; // 与rightTerrain碰撞，开始向左移动
        }
    }
}
