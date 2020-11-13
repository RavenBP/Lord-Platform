using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float speed = 5.0f;

    public static int playerLives;

    float xSeperation = 0.3f; // NOTE: A ySperation will likely need to be made in order to prevent the player from jumping when pressing pause button...

    Vector2 screenTouchPosition;

    // Jumping
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    private int extraJumps;
    public int extraJumpsValue;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = 3; // Reset player lives
        extraJumps = extraJumpsValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue; // Reset jumps
        }

        screenTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            if (screenTouchPosition.x > 0.6f && extraJumps > 0) // Player is attempting to jump in air
            {
                rigidbody2D.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (screenTouchPosition.x > 0.6f && extraJumps == 0 && isGrounded == true) // Player is attempting to jump
            {
                rigidbody2D.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground); // Player is on "Ground" Layer

        if (Input.touchCount > 0)
        {
            if (screenTouchPosition.x > xSeperation && screenTouchPosition.x < 0.6f) // Player attempting to move right
            {
                rigidbody2D.velocity = new Vector2(1.0f * speed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = false;
            }
            else if (screenTouchPosition.x < xSeperation) // Player attempting to move left
            {
                rigidbody2D.velocity = new Vector2(-1.0f * speed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = true;
            }
        }
        else // Player does not want to move
        {
            rigidbody2D.velocity = new Vector2(0.0f, rigidbody2D.velocity.y); // Stop velocity on x axis
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bounds"))
        {
            playerLives--;

            if (playerLives < 1) // Player has no remaining lives/health
            {
                SceneManager.LoadScene("GameOverScene");
            }
            else // Player still has lives
            {
                transform.position = new Vector2(-3.0f, 2.0f); // TODO: Replace with checkpoint value...
            }
        }
    }
}
