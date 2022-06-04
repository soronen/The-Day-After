using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    /// <summary>
    /// value for "is game paused or not", original value game is not paused
    /// </summary>
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    /// <summary>
    /// Is waiting for the player to activate the pause menu by pressing esc
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    /// <summary>
    /// Hides the pause menu and continues the game
    /// </summary>
    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }


    /// <summary>
    /// Pops up the pause menu and stops the game while the menu is open
    /// </summary>
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    /// <summary>
    /// Switches the game to main menu scene
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene("main menu");
    }


    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
