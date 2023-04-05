using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         Debug.Log("Game exiting");
    //         Application.Quit();

    //     }
    // }

    
   public void Load(string sceneToLoad)
    {
        SceneManager.LoadScene("Circuit Track");
        Debug.Log("Game loaded");

    }

    public void ExitGame()
    {
     Application.Quit();
     Debug.Log("Game exiting");
    }


}
