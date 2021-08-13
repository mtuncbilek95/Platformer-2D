using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        LockMouse();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPauseButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameIsPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void ContinueGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        LockMouse();
    }
    private void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        UnlockMouse();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadScene("DemoScene");
        LockMouse();
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        LockMouse();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        SceneManager.LoadScene("MenuScene");
        UnlockMouse();
    }

    private void LockMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void UnlockMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
