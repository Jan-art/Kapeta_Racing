using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject WinPanel;
    public GameObject LossPanel;
    public GameObject raceEnd_Trig;
    public GameObject AIVehicle; //AI Vehicle
    public static bool StateOn = false;

    public void MuteSceneSound()
    {
        // Get all AudioSources in the current scene and set their volume to 0
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.volume = 0;
        }
    }

    public void UnMuteSceneSound()
    {
        // Get all AudioSources in the current scene and set their volume to 1
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            source.volume = 1;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GhostKart01"))
        {
            raceEnd_Trig.SetActive(false);
            LossPanel.SetActive(true);
            Time.timeScale = 0f;
            StateOn = true;
             MuteSceneSound();

            Debug.Log("Loss");
        }
        else
        {
            raceEnd_Trig.SetActive(false);
            WinPanel.SetActive(true);
            Time.timeScale = 0f;
            StateOn = true;
             MuteSceneSound();

            Debug.Log("Win");
        }
    }
}
