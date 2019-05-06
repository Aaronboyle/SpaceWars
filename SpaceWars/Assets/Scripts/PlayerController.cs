using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float tilt;
    public Boundary boundary;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        Vector3 bounds = new Vector3((Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax)), 0.0f, (Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)));

        rb.position = bounds;

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, (rb.velocity.x * -tilt));
    }
}

    [System.Serializable]
    public class Boundary
    {

        public float xMin, xMax, zMin, zMax;

    }﻿
    
