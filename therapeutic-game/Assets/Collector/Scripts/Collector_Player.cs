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
    private Text _playerText;
    public GameObject ball;
    private float _fallSpeed;
    private float _spawnSpeed;
    private float _topBorder;
    private float _leftBorder;
    private float _rightBorder;
    private float _bottomBorder;
    void Start()
    {
        _fallSpeed = MainMenu.FallSpeedValue;
        _spawnSpeed = MainMenu.SpawnSpeedValue;
        _playerText = playerScore.GetComponent<Text>();
        
        Vector3 screenSize = MainMenu.ScreenSizeVector;
        _topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        _leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        _rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
        _bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;
    }
    
    void Update()
    {
        Camera cam = Camera.main;
        Vector3 mousePos = Mouse.current.position.ReadValue();

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero);
        if(hit.collider != null && (hit.collider.name == "transparent_box" || hit.collider.name == "transparent_top") || PauseMenu.GamePaused)
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
            _playerText.text = (Int16.Parse(_playerText.text)+1).ToString();
            CollectGameManager.Drops.Remove(col.gameObject);
            Destroy(col.gameObject);
            spawnNewEnemy();
            //Invoke("spawnNewEnemy", _s_spawnSpeed);
        }
    }
    
    private void spawnNewEnemy()
    {       
        if (!MainMenu.ConstantFallValue)
        {
            CollectGameManager.FallSpeed += 0.1f;
            _fallSpeed = CollectGameManager.FallSpeed;
        }
        GameObject Drop = Instantiate(ball, new Vector3(Random.Range(_leftBorder,_rightBorder), (_topBorder+1), 0), Quaternion.identity);
        Vector2 movement = new Vector2(0, -_fallSpeed);
        
        Drop.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
        CollectGameManager.Drops.Add(Drop);
    }
}
