using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public static bool StateOn = false;
    public GameObject pauseMenuCanvas;
    public GameObject speedCanvas;

    void Start()
    {
        Time.timeScale = 1f;
        pauseMenuCanvas.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        
        {
            Debug.Log("Escape Pressed");
            if (StateOn)
            {
                Resume();
                Debug.Log("Game was UnPaused");
            }
            else
            {
                Pause();
                Debug.Log("Game was Paused");
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Function Resume() was called");
        pauseMenuCanvas.SetActive(false);
        
        Time.timeScale = 1f;
        StateOn = false;
        speedCanvas.SetActive(true);
    }

    void Pause()
    {
        Debug.Log("Function Pause() was called");
        pauseMenuCanvas.SetActive(true);
        
        Time.timeScale = 0f;
        StateOn = true;
        speedCanvas.SetActive(false);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

}
