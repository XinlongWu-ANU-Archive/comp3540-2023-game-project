using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    protected GameManager gameManager;

    private bool _faceToRight = true;
    protected float speed = 3;
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

    private bool _isInvincibility = false;
    private float invincibilityTimer = 0;
    private float maxInvincibilityTime = 3f;
    public CameraShake cameraShake;

    // Start is called before the first frame update
    protected void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        playerRb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();        
    }

    // Update is called once per frame
    protected void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

        if  (Input.GetKeyDown(KeyCode.Space))
            jump();

        if (isJump && playerRb2D.velocity.y < -0.5f)
            isFall = true;

        if (isInvincibility)
        {
            invincibilityTimer += Time.deltaTime;
            if (invincibilityTimer >= maxInvincibilityTime)
            {
                //playerRb2D.bodyType = RigidbodyType2D.Dynamic;
                //collider2D.isTrigger = false;
                isInvincibility = false;
            }
        }

    }

    void jump()
    {
        if (!isJump)
        {
            SoundManager.instance.PlaySound(SoundManager.instance.jumpSound,0.2f);
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJump = true;
            animator.Play("Jump");
        }
    }

    void hited()
    {
        if (!isInvincibility)
        {
            SoundManager.instance.PlaySound(SoundManager.instance.hitSound,0.2f);
            animator.Play("Hit");
            isInvincibility = true;
            cameraShake.ShakeCamera();
            //playerRb2D.bodyType = RigidbodyType2D.Kinematic;
            //collider2D.isTrigger = true;
            invincibilityTimer = 0;
            gameManager.UpdateLife();
        }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("Trap"))
        {
            //Debug.Log("objecttag:"+collision.gameObject.tag);
            Vector2 hitPoint = collision.collider.ClosestPoint(transform.position);
            float objBound = collider2D.size.x / 2;

            if (hitPoint.y < transform.position.y && (transform.position.x - hitPoint.x <= objBound && transform.position.x - hitPoint.x >= -objBound))
            {
                isJump = false;
                isFall = false;
            }

            if (collision.gameObject.CompareTag("Trap"))
            {
                hited();
                
            }
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            hited();
        }
        else if (collision.gameObject.CompareTag("Seed"))
        {
            hited();
        }

    }

    private bool isInvincibility
    {
        get
        {
            return _isInvincibility;
        }
        set
        {
            _isInvincibility = value;
            animator.SetBool("isInvincibility", value);
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
    protected float horizontalInput
    {
        get { return _horizontalInput; }
        set
        {
            animator.SetBool("isRun", value != 0);
            if (_horizontalInput == 0 && value != 0 && !isInvincibility)
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

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        // If the player trigger the EnterGate, player has passed current level and will enter next level
         if (collision.CompareTag("EnterGate"))
        {
            LoadScene();
        }
    }

    // Load to the scene of next level
    public void LoadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Level0")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (currentSceneName == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentSceneName == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
    }
    
}
