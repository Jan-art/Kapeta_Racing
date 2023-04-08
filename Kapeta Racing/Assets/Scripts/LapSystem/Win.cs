using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject raceEnd_Trig;
    public static bool StateOn = false;

    public void MuteAllSound()
    {
    AudioListener.volume = 0;
    }

    public void UnMuteAllSound()
    {
    AudioListener.volume = 1;
    }


    void OnTriggerEnter()
    {
     
        raceEnd_Trig.SetActive(false);
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
        StateOn = true;
        MuteAllSound();
       
      
        Debug.Log("Win");
    }
}
