using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public static bool StateOn = false;
    public GameObject PauseMenu;
    public GameObject SpeedCanvas;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        Debug.Log("Escape Pressed");
        {
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
        PauseMenu.SetActive(false);
        
        //Time.timeScale = 1f;
        StateOn = false;
        SpeedCanvas.SetActive(false);
    }

    void Pause()
    {
        Debug.Log("Function Pause() was called");
        PauseMenu.SetActive(true);
        
        //Time.timeScale = 0f;
        StateOn = true;
        SpeedCanvas.SetActive(true);
    }

}
