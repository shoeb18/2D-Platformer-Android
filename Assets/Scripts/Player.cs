using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int health = 3;

    private Rigidbody2D rb;
    private bool jump = false;
    private float horizontalMove;
    private SpriteRenderer spriteRenderer;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    private bool isGrounded = false;

    public Transform black;
    public Transform white;

    // Create Player Singleton
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // flipping the player 
        if (Input.GetMouseButtonDown(0))
        {
            FlipPlayer();
        }


        // checking player jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // getting player movement input
        horizontalMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        // checking ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // make player move
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);

        // make player jump
        if (jump && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }

    }

    // collecting coins
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    // Taking player damage
    public void TakeDamage(int damage)
    {
        if (health <= 0){
            Debug.Log("Game Over!");
        }
        health -= damage;
    }

    // flip the player 
    void FlipPlayer()
    {
        if (spriteRenderer.flipY)
        {
            spriteRenderer.flipY = false;
            FlipBlackUp();
        }
        else
        {
            spriteRenderer.flipY = true;
            FlipBlackDown();
        }
    }

    // flip the black and white sides
    void FlipBlackUp()
    {
        black.position = gameObject.transform.position + new Vector3(0, 0.6f, 0);
        white.position = gameObject.transform.position + new Vector3(0, -0.6f, 0);
    }

    void FlipBlackDown()
    {
        black.position = gameObject.transform.position + new Vector3(0, -0.6f, 0);
        white.position = gameObject.transform.position + new Vector3(0, 0.6f, 0);
    }
}
