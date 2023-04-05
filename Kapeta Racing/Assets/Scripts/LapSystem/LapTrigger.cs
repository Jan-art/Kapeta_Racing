using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapTrigger : MonoBehaviour
{
 
 public GameObject LapFinishTrig;
 public GameObject HalfLapTrig;

    void OnTriggerEnter()
    {
    LapFinishTrig.SetActive(true);
    Debug.Log("Wall-1 Triggered");

    HalfLapTrig.SetActive(false);
    Debug.Log("Wall-2 Triggered");
    }


}
