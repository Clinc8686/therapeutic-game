using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 10.0f;
    private Vector3 screenSize;
    private float topBorder;
    private float bottomBorder;
    private float deviation = 0.25f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 movement = new Vector2(Random.Range(0,2)*2-1, Random.Range(0.5f, 2.0f)*2-2);
        
        rb.AddForce(movement * speed, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
        
        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;
    }
    
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if((transform.position.y <= bottomBorder+deviation)){
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        }
         
        if((transform.position.y >= topBorder-deviation)){
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        }
    }
}
