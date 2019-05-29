using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && GameIsPaused)
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.M) && GameIsPaused)
        {
            Resume();
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.R) && GameIsPaused)
        {
            Resume();
            SceneManager.LoadScene(2);
        }
    }
}
