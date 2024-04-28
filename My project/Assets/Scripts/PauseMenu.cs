using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool settingsIsOpen = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && settingsIsOpen)
            {
                CloseSettingsMenu();
            }
            else if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void OpenSettingsMenu()
    {
        settingsIsOpen = true;
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void CloseSettingsMenu()
    {
        settingsIsOpen = false;
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("lmao we not quittin");
    }
}
