using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider SliderFall;
    [SerializeField] private Text SliderFallText;
    [SerializeField] private Slider SliderSpawn;
    [SerializeField] private Text SliderSpawnText;
    [SerializeField] private Toggle ConstantFall;
    public static int FallSpeedValue;
    public static float SpawnSpeedValue;
    public static bool constantFallValue = true;

    private void Start()
    {
        FallSpeedValue = (int) SliderFall.value;
        SpawnSpeedValue = SliderSpawn.value;
        constantFallValue = ConstantFall.isOn;
    }

    public void FallValueChanged()
    {
        SliderFallText.text = SliderFall.value.ToString("F0");
        FallSpeedValue = (int) SliderFall.value;
    }
    
    public void SpawnValueChanged()
    {
        SliderSpawnText.text = SliderSpawn.value.ToString("0.0");
        SpawnSpeedValue = SliderSpawn.value;
    }

    public void ConstantFallChanged()
    {
        constantFallValue = ConstantFall.isOn;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
