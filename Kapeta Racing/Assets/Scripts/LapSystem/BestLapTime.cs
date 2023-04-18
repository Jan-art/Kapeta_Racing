using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BestLapTime : MonoBehaviour
{
    public int min_Track;
    public int sec_Track;
    public float ms_Track;
    
    public GameObject MinDisplay;
    public GameObject SecDisplay;
    public GameObject MlsDisplay;

    void Start()
    {

        min_Track = PlayerPrefs.GetInt("MinuteSave");
        sec_Track = PlayerPrefs.GetInt("SecondSave");
        ms_Track = PlayerPrefs.GetFloat("MilliSave");
        
        MinDisplay.GetComponent<TMP_Text>().text = min_Track.ToString("D2") + ":";
        SecDisplay.GetComponent<TMP_Text>().text = sec_Track.ToString("D2") + ".";
        MlsDisplay.GetComponent<TMP_Text>().text = ms_Track.ToString("f0");
    }
}
