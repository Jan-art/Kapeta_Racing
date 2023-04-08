using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trigger Script to activate the next lap trigger
public class LapTrigger : MonoBehaviour
{
 
 public GameObject LapFinishTrig;
 public GameObject HalfLapTrig;


    void OnTriggerEnter()
    {
    LapFinishTrig.SetActive(true);
    Debug.Log("Wall-1 Activated");

    HalfLapTrig.SetActive(false);
    Debug.Log("Wall-2 Closed");
    }

 
}
