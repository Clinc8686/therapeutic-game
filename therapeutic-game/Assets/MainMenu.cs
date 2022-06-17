using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Slider sliderFall;
    [SerializeField] private Text sliderFallText;
    [SerializeField] private Slider sliderSpawn;
    [SerializeField] private Text sliderSpawnText;
    [SerializeField] private Toggle constantFall;
    [SerializeField] private Slider sliderTransparentBoxHeight;
    [SerializeField] private Text sliderTransparentBoxHeightText;
    public static float transparentBoxHeight;
    public static float _screenSize;
    public static Vector3 ScreenSizeVector;
    public static int FallSpeedValue = 1;
    public static float SpawnSpeedValue;
    public static bool ConstantFallValue = true;

    private void Start()
    {
        ScreenSizeVector = Camera.main.WorldToViewportPoint(transform.position);
        _screenSize = (Camera.main.ViewportToWorldPoint(new Vector3(0, 1, ScreenSizeVector.z)).y)*2;
        sliderTransparentBoxHeight.maxValue = _screenSize;
        FallSpeedValue = MainMenu.FallSpeedValue;
        SpawnSpeedValue = sliderSpawn.value;
        ConstantFallValue = constantFall.isOn;
        transparentBoxHeight = sliderFall.value;
    }

    public void FallValueChanged()
    {
        sliderFallText.text = sliderFall.value.ToString("F0");
        FallSpeedValue = (int) sliderFall.value;
    }

    public void TransparentBoxChanged()
    {
        sliderTransparentBoxHeightText.text = sliderTransparentBoxHeight.value.ToString("F0");
        transparentBoxHeight = sliderTransparentBoxHeight.value;
    }
    
    public void SpawnValueChanged()
    {
        sliderSpawnText.text = sliderSpawn.value.ToString("0.0");
        SpawnSpeedValue = sliderSpawn.value;
    }

    public void ConstantFallChanged()
    {
        ConstantFallValue = constantFall.isOn;
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
