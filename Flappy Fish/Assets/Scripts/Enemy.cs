using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;        // the movement speed of the enemy
    private Rigidbody2D rb;         // reference to the rigibody
    private SpriteRenderer sr;      // reference to the sprite renderer component

    private void Start()
    {
        // Setting up the references
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(speed, 0) * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + movement);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the enemy collides with a gameobject tagged bounds
        if (collision.tag == ("Bounds"))
        {
            // this flips the sprite
            sr.flipX = !sr.flipX;

            // this "flips" the dir
            speed *= -1;
        }
    }
}



