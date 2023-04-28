using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This script is used to keep track of the time
public class TimeManager : MonoBehaviour
{
   // Time Variables
   public static int min_Track;
   public static int sec_Track;
   public static float ms_Track;
   public static string mls_Show;

   // UI Elements
   public GameObject min_Box;
   public GameObject s_Box;
   public GameObject mls_Box;

   public static float originTime;

    // Update is called once per frame
    void Update()
    {
        ms_Track += Time.deltaTime * 10;
        originTime += Time.deltaTime;
        mls_Show = Mathf.Floor(ms_Track).ToString("f0");
        mls_Box.GetComponent<TMP_Text>().text = "" + mls_Show;

        if (ms_Track >= 10)
        {
            ms_Track -= 10;
            sec_Track += 1;
        }



        if (sec_Track <= 9)
        {
            s_Box.GetComponent<TMP_Text>().text = "0" + sec_Track + ".";
        }
        else
        {
            s_Box.GetComponent<TMP_Text>().text = "" + sec_Track + ".";
        }

        if (sec_Track >= 60)
        {
            sec_Track = 0;
            min_Track += 1;
        }

        if (min_Track <= 9)
        {
            min_Box.GetComponent<TMP_Text>().text = "0" + min_Track + ":";
        }
        else
        {
            min_Box.GetComponent<TMP_Text>().text = "" + min_Track + ":";
        }

    }
}
