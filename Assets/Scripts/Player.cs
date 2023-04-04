using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Attributes")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;

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

    // flip the player 
    void FlipPlayer()
    {
        if (spriteRenderer.flipY)
        {
            spriteRenderer.flipY = false;
            FlipBlackDown();
        }
        else
        {
            spriteRenderer.flipY = true;
            FlipBlackUp();
        }
    }

    // flip the black and white sides
    void FlipBlackDown()
    {
        black.position = gameObject.transform.position + new Vector3(0, 0.6f, 0);
        white.position = gameObject.transform.position + new Vector3(0, -0.6f, 0);
    }

    void FlipBlackUp()
    {
        black.position = gameObject.transform.position + new Vector3(0, -0.6f, 0);
        white.position = gameObject.transform.position + new Vector3(0, 0.6f, 0);
    }
}
