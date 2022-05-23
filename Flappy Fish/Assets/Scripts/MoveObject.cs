using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1;     // the speed of the object
    private Rigidbody2D rb;     // reference to the rigidbody

    void Start()
    {
        // setting up the references
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

    }
}
