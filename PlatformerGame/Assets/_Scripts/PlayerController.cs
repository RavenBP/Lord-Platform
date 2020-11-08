using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigidbody2D;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float speed = 5.0f;

    float xSeperation = 0.3f;

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
}
