using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private int scoreToAdd = 5;

    private bool _faceToRight;
    private float speed = 3;
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 5;
    private float hitForce = 2;
    private BoxCollider2D collider2D;
    private Rigidbody2D playerRb2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    // dont use following parameters directly, use getter and setter.
    private bool _isJump = false;
    private float _horizontalInput = 0f;
    private bool _isFall = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        playerRb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
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
        else if (collision.gameObject.CompareTag("Monster") || collision.gameObject.CompareTag("Trap"))
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
    private float horizontalInput
    {
        get { return _horizontalInput; }
        set
        {
            animator.SetBool("isRun", value != 0);
            if (_horizontalInput == 0 && value != 0)
                animator.Play("Run");
            if (value < 0)
                faceToRight = false;
            else if (value > 0)
                faceToRight = true;
            _horizontalInput = value;
        }
    }

    private bool isFall
    {
        get { return _isFall; }
        set
        {
            animator.SetBool("isFall", value);
            _isFall = value;
        }
    }

    public bool faceToRight
    {
        get
        {
            return _faceToRight;
        }
        set
        {
            _faceToRight = value;
            spriteRenderer.flipX = !value;
        }
    }

    // Collect fruit and add score when the player touch the fruit
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore(scoreToAdd);
        }
    }
}
