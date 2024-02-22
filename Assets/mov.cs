using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement du joueur
    public float jumpForce = 10f; // Force de saut du joueur

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D body;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    [SerializeField] private BoxCollider2D bc2d3;
    private bool grounded;
    private int jumps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Jump()
    {

        body.velocity = new Vector2(body.velocity.x, jump * 2);
        if (jumps == 0)
            grounded = false;
        else
            jumps--;
    }

    private void Update()
    {
        if (body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d3))
        {
            gameObject.transform.position = new Vector3(11, -3, 0);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > -0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumps = 5;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Vérifier si le joueur quitte le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}