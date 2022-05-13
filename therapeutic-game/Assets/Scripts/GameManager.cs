using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject player1Score;
    public GameObject player2Score;
    private Text player1Text;
    private Text player2Text;
    public GameObject Ball;
    private float speed = 10.0f;
    
    private Vector3 screenSize;
    private float leftBorder;
    private float rightBorder;
    private float deviation = 0.25f;
    
    void Start()
    {
        Ball = Instantiate(Ball, new Vector3(0, 0, 0), Quaternion.identity);
        player1Text = player1Score.GetComponent<Text>();
        player2Text = player2Score.GetComponent<Text>();
        
        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Ball != null)
        {
            if((Ball.transform.position.x <= leftBorder-deviation)){
                player1Text.text = (Int16.Parse(player1Text.text)+1).ToString();
                spawnBallNew(1);
            } else if((Ball.transform.position.x >= rightBorder+deviation)) {
                player2Text.text = (Int16.Parse(player2Text.text)+1).ToString();
                spawnBallNew(-1);
            }   
        }
    }

    private void spawnBallNew(int direction)
    {
        Rigidbody2D rb = Ball.GetComponent<Rigidbody2D>();
        Ball.transform.position = new Vector3(0, 0, 0);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        
        Vector2 movement = new Vector2(direction, Random.Range(0.5f, 2.0f)*2-2);
        rb.AddForce(movement * speed, ForceMode2D.Impulse);
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);

        
    }
}
