using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following
    public float smoothing = 5f;        // The speed with which the camera will be following

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }


    void FixedUpdate()
    {
        // Create a postion the camera is aiming
        Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}