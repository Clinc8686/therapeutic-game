using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using Random = UnityEngine.Random;

public class CollectGameManager : MonoBehaviour
{
    public GameObject playerScore;
    private Text playerText;
    public GameObject Ball;
    private float speed = 5.0f;
    private Vector3 screenSize;
    private float topBorder;
    private float leftBorder;
    private float rightBorder;
    private float bottomBorder;
    private float deviation = 0.25f;
    public static List<GameObject> Drops;

    void Start()
    {
        Drops = new List<GameObject>();
        playerText = playerScore.GetComponent<Text>();

        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;
        spawnNewEnemy();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (GameObject Drop in Drops)
        {
            if (Drop.transform.position.y <= bottomBorder)
            {
                playerText.text = (Int16.Parse(playerText.text)-1).ToString();
                Drops.Remove(Drop);
                Destroy(Drop);
                spawnNewEnemy();
                return;
            }
        }
    }

    private void spawnNewEnemy()
    {
        GameObject Drop = Instantiate(Ball, new Vector3(Random.Range(leftBorder,rightBorder), (topBorder+1), 0), Quaternion.identity);
        Vector2 movement = new Vector2(0, -speed);
        
        Drop.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
        Drops.Add(Drop);
    }

}
