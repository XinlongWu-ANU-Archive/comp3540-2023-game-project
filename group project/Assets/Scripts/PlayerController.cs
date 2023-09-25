using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3;
    private Rigidbody2D rigidbody2D;
    private float jumpForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
