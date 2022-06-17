using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    [SerializeField] private GameObject PauseMenuUI;

    public void ResumeClicked()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    public void QuitClicked()
    {
        Application.Quit();
    }

    public void MenuClicked()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnEscape(InputValue value)
    {
        if (GamePaused)
        {
            ResumeClicked();
        }
        else
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GamePaused = true;
        }
    }
}
