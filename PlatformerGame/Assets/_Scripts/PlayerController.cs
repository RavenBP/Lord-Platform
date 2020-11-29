// File Name: PlayerController.cs
// Author: Raven Powless - 101173103
// Last Modified: 11/28/20
// Description: Script that takes in input from the player and allows them to move their avatar within the game.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 5.0f;

    public static int playerLives;
    public static bool completedLevel = false;

    float xSeperation = 0.3f;

    Vector2 screenTouchPosition;

    [Header("Jumping")]
    public float jumpForce;
    public int extraJumpsValue;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;

    private bool isGrounded;
    private bool soundPlaying;

    private int extraJumps;

    [Header("Audio")]
    [SerializeField]
    AudioClip[] audioClips;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        playerLives = 3; // Reset player lives
        extraJumps = extraJumpsValue;
        completedLevel = false; // Reset player lives upon initialization of player
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue; // Reset jumps
            animator.SetBool("InAir", false);
        }
        else if (isGrounded == false)
        {
            animator.SetBool("InAir", true);
        }

        screenTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.touchCount > 0)
        {
            if (screenTouchPosition.x > xSeperation * 2.0f && screenTouchPosition.y < 0.6f && extraJumps > 0) // Player is attempting to jump in air
            {
                rigidbody2D.velocity = Vector2.up * jumpForce;
                extraJumps--;

                // NOTE: Because this is here, it will likely be played more than intended...
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            //else if (screenTouchPosition.x > 0.6f && extraJumps == 0 && isGrounded == true) // Player is attempting to jump
            //{
            //    rigidbody2D.velocity = Vector2.up * jumpForce;
            //}
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

                animator.SetFloat("Speed", 1);
            }
            else if (screenTouchPosition.x < xSeperation) // Player attempting to move left
            {
                rigidbody2D.velocity = new Vector2(-1.0f * speed, rigidbody2D.velocity.y);
                spriteRenderer.flipX = true;

                animator.SetFloat("Speed", 1);
            }
        }
        else // Player does not want to move
        {
            rigidbody2D.velocity = new Vector2(0.0f, rigidbody2D.velocity.y); // Stop velocity on x axis

            animator.SetFloat("Speed", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bounds"))
        {
            playerLives--;

            audioSource.clip = audioClips[1];
            audioSource.Play();

            if (playerLives < 0) // Player has no remaining lives/health
            {
                SceneManager.LoadScene("GameOverScene");
            }
            else // Player still has lives
            {
                transform.position = new Vector2(-3.0f, 2.0f); // TODO: Replace with checkpoint value...
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FinishLine"))
        {
            completedLevel = true;
            SceneManager.LoadScene("GameOverScene");
            Debug.Log("The player completed the level");
        }
    }
}
