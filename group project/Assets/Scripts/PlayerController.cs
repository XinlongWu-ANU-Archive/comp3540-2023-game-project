using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 5;
    private BoxCollider2D collider2D;
    private Animator animator;

    private bool _isJump = false;
    private bool isJump
    {
        get { return _isJump; }
        set
        {
            _isJump = value;
            animator.SetBool("isJump", value);
        }
    }

    private bool _isRun = false;
    private bool isRun
    {
        get { return _isRun; }
        set
        {
            _isRun = value;
            animator.SetBool("isRun", value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        if (horizontalInput == 0)
            isRun = false;
        else
            isRun = true;

        if  (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            jump();
    }

    void jump()
    {
        if (!isJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Vector2 hitPoint = collision.collider.ClosestPoint(transform.position);
            float objBound = collider2D.size.x / 2;
            if (hitPoint.y > collision.transform.position.y && (transform.position.x - hitPoint.x <= objBound && transform.position.x - hitPoint.x >= -objBound))
            {
                isJump = false;
            }
        }

    }
}
