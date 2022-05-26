using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Smiley_Manager : MonoBehaviour
{
    [SerializeField] private Sprite smiley_smiling_eyes;
    [SerializeField] private Sprite smiley_raised_eyebrown;
    [SerializeField] private Sprite smiley_sad_but_relieved;

    private Rigidbody2D rb;
    private float speed = 50.0f;
    private Vector3 screenSize;
    private float leftBorder;
    private float rightBorder;
    private float topBorder;
    private float bottomBorder;
    private float deviation = 0.70f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;

        Vector2 movement = new Vector2(Random.Range(0.2f, 4)*2-4, Random.Range(0.2f, 4)*2-4);
        rb.AddForce(movement * speed);
    }
    
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if((transform.position.x <= leftBorder+deviation) && rb.velocity.x < 0f){
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
        }
         
        if((transform.position.x >= rightBorder-deviation) && rb.velocity.x > 0){
            rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, 0);
        }
         
        if((transform.position.y <= bottomBorder+deviation) && rb.velocity.y < 0){
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        }
         
        if((transform.position.y >= topBorder-deviation) && rb.velocity.y > 0){
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, 0);
        }
    }
}
