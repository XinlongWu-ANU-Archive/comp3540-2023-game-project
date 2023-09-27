using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 5;
    private BoxCollider2D collider2D;
    private Rigidbody2D playerRb2D;
    private Animator animator;

    // dont use following parameters directly, use getter and setter.
    private bool _isJump = false;
    private bool _isRun = false;
    private bool _isFall = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        playerRb2D = GetComponent<Rigidbody2D>();
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

        if (isJump && playerRb2D.velocity.y < -0.5f)
            isFall = true;

    }

    void jump()
    {
        if (!isJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
            animator.Play("Jump");
        }
    }

    void hited()
    {
        animator.Play("Hit");
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
                isFall = false;
            }
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            hited();
        }
    }


    private bool isJump
    {
        get { return _isJump; }
        set
        {
            _isJump = value;
            animator.SetBool("isJump", value);
        }
    }
    private bool isRun
    {
        get { return _isRun; }
        set
        {
            animator.SetBool("isRun", value);
            if (_isRun == false && value == true)
                animator.Play("Run");
            _isRun = value;
        }
    }

    private bool isFall
    {
        get { return _isFall; }
        set
        {
            animator.SetBool("isFall", value);
            _isRun = value;
        }
    }
}
