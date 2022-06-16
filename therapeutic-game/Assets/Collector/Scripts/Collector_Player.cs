using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Collector_Player : MonoBehaviour
{
    public GameObject player;
    public GameObject playerScore;
    private Text playerText;
    public GameObject Ball;
    private float FallSpeed;
    private float SpawnSpeed;
    private Vector3 screenSize;
    private float topBorder;
    private float leftBorder;
    private float rightBorder;
    private float bottomBorder;
    void Start()
    {
        FallSpeed = MainMenu.FallSpeedValue;
        SpawnSpeed = MainMenu.SpawnSpeedValue;
        playerText = playerScore.GetComponent<Text>();
        
        screenSize = Camera.main.WorldToViewportPoint(transform.position);
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;
    }
    
    void Update()
    {
        Camera cam = Camera.main;
        Vector3 mousePos = Mouse.current.position.ReadValue();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
        if(hit.collider != null && (hit.collider.name == "transparent_box" || hit.collider.name == "transparent_top"))
        {
            //Debug.Log ("Target name: " + hit.collider.name);
        } else
        {
            Vector3 cursorPosition = new Vector3(cam.ScreenToWorldPoint(mousePos).x, cam.ScreenToWorldPoint(mousePos).y, 0); 
            player.transform.position = new Vector3(cursorPosition.x,player.transform.position.y, 0);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            playerText.text = (Int16.Parse(playerText.text)+1).ToString();
            CollectGameManager.Drops.Remove(col.gameObject);
            Destroy(col.gameObject);
            spawnNewEnemy();
            //Invoke("spawnNewEnemy", SpawnSpeed);
        }
    }
    
    private void spawnNewEnemy()
    {
        GameObject Drop = Instantiate(Ball, new Vector3(Random.Range(leftBorder,rightBorder), (topBorder+1), 0), Quaternion.identity);
        Vector2 movement = new Vector2(0, -FallSpeed);
        
        Drop.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
        CollectGameManager.Drops.Add(Drop);
    }
}
