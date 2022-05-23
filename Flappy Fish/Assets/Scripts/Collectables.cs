using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public GameObject particleEffect;           // reference to the particle system
    public AudioSource collectableSound;        // reference to the AudioSource


    void OnTriggerEnter2D(Collider2D collision)
    {
        // if the gameobject tagged player collides with this collider
        if (collision.gameObject.CompareTag("Player"))
        {
            // add to the score amount
            ScoreManager.scoreAmount++;
            //disable the gameobject
            gameObject.SetActive(false);
            Debug.Log("Point Collected");
            // spawn the particle effect
            Instantiate(particleEffect, transform.position, transform.rotation);
            collectableSound.Play();
        }
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
    }
}