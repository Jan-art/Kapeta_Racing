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
   
   public string link;
    
   public void LoadLevelSelection(string sceneToLoad)
    {
        SceneManager.LoadScene("Track_Select");
        Debug.Log("Game loaded");

    }

    public void LoadLevel1(string sceneToLoad)
    {
        SceneManager.LoadScene("Map1");
        Debug.Log("Game loaded");

    }

    public void LoadLevel2(string sceneToLoad)
    {
        SceneManager.LoadScene("Map2");
        AudioListener.volume = 1;
        Debug.Log("Game loaded");

    }

    public void ExitGame()
    {
     Application.Quit();
     Debug.Log("Game exiting");
    }

   public void LoadGit()
   {
     Application.OpenURL(link); //URL needs to be changed from button : )
     Debug.Log("Git loaded");
   }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}
