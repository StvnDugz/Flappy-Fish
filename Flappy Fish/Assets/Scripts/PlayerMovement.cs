using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //declaring variables
    public float velocity = 5;
    public float swimForce = 250f;
    float moveHorizontal;
    public AudioClip deathClip;                     // the sound to play when the player dies
    public GameObject particleEffect;               // reference to the particle system
    private AudioSource playerAudio;                // reference to the AudioSource
    private Animator anim;                          // reference to the animaator
    private Rigidbody2D rb;                         // reference to the rigidbody
    private SpriteRenderer sr;                      // reference to the sprite renderer
    private bool isDead = false;
    private CircleCollider2D playerCollider;        // reference to the players collider



    void Start()
    {
        // Setting up the references
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerAudio = GetComponent<AudioSource>();
        playerCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is alive
        if (isDead == false)
        {
            // if the space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // vertical movement
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, swimForce));
                anim.SetTrigger("swim");
                playerAudio.Play();
            }

            // horizontal movement
            moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 horizontalMovement = new Vector2(moveHorizontal, 0);
            rb.AddForce(horizontalMovement * velocity);

            CheckForFlip();
        }


    }

    // A function that checks if the player character is flipped 
    public void CheckForFlip()
    {
            // if the right horizontal input key is pressed
            if (Input.GetAxis("Horizontal") < 0)
            {
                // move on the horizontal axis
                moveHorizontal = 1f;
                sr.flipX = true;
            }
            // if the left horizontal input key is pressed
            else if (Input.GetAxis("Horizontal") > 0)
            {
                // move on the horizontal axis 
                moveHorizontal = -1f;
                sr.flipX = false;
            }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the player collides with a gameobject tagged damage
        if (collision.gameObject.CompareTag("Damage"))
        {
            rb.velocity = Vector2.zero;
            isDead = true;
            anim.SetTrigger("die");
            playerAudio.clip = deathClip;
            playerAudio.Play();
            Instantiate(particleEffect, transform.position, transform.rotation);
            GameOverManager.instance.Die();
            playerCollider.enabled = false;
        }
    }
}