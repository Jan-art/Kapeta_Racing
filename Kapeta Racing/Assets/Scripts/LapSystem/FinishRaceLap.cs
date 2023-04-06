using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinishRaceLap : MonoBehaviour
{
   public GameObject LapFinish_Trig;
   public GameObject HalfLap_Trig;

    public GameObject Min_Display;
    public GameObject Sec_Display;
    public GameObject Mls_Display;

    public GameObject LapTimeBox;

    void OnTriggerEnter(){

    if (TimeManager.sec_Track <= 9)
    {
        Sec_Display.GetComponent<TMP_Text>().text = "0" + TimeManager.sec_Track + ".";
    }
    else
    {
        Sec_Display.GetComponent<TMP_Text>().text = "" + TimeManager.sec_Track + ".";
    }

    if (TimeManager.min_Track <= 9)
    {
        Min_Display.GetComponent<TMP_Text>().text = "0" + TimeManager.min_Track + ":";
    }
    else
    {
        Min_Display.GetComponent<TMP_Text>().text = "" + TimeManager.min_Track + ":";
    }

    Mls_Display.GetComponent<TMP_Text>().text = "" + TimeManager.mls_Show;

    TimeManager.min_Track = 0;
    TimeManager.sec_Track = 0;
    TimeManager.ms_Track = 0;

    HalfLap_Trig.SetActive(true);
    LapFinish_Trig.SetActive(false);
    }
    
}
