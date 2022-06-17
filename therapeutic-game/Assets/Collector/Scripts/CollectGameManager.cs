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
    private Text _playerText;
    public GameObject ball;
    public static float FallSpeed;
    private static float _spawnSpeed;
    public float topBorder;
    public float leftBorder;
    public float rightBorder;
    public float bottomBorder;
    public static List<GameObject> Drops;

    void Start()
    {
        FallSpeed = MainMenu.FallSpeedValue;
        _spawnSpeed = MainMenu.SpawnSpeedValue;
        
        Drops = new List<GameObject>();
        _playerText = playerScore.GetComponent<Text>();

        Vector3 screenSize = MainMenu.ScreenSizeVector;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, screenSize.z)).y;
        Debug.Log(topBorder + " " + bottomBorder);
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, screenSize.z)).x;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, screenSize.z)).y;
        SpawnNewEnemy();
    }

    private void FixedUpdate()
    {
        foreach (GameObject drop in Drops)
        {
            if (drop.transform.position.y <= bottomBorder)
            {
                _playerText.text = (Int16.Parse(_playerText.text)-1).ToString();
                Drops.Remove(drop);
                Destroy(drop);
                SpawnNewEnemy();
                return;
            }
        }
    }

    private void SpawnNewEnemy()
    {
        if (!MainMenu.ConstantFallValue)
        {
            FallSpeed = FallSpeed + 0.1f;
        }
        GameObject drop = Instantiate(ball, new Vector3(Random.Range(leftBorder,rightBorder), (topBorder+1), 0), Quaternion.identity);
        Vector2 movement = new Vector2(0, -FallSpeed);
        
        drop.GetComponent<Rigidbody2D>().AddForce(movement, ForceMode2D.Impulse);
        Drops.Add(drop);
    }
}
