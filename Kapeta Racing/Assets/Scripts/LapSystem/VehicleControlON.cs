using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

//Script to stop vehicle controls before countdown is finished
public class VehicleControlON : MonoBehaviour {

  public GameObject vehicleControl;
      public GameObject GhostKart01;

 void Start () {

       vehicleControl.GetComponent<WheelDriveOption>().enabled = false;
       GhostKart01.GetComponent<CarAIControl>().enabled = false;
        
 }
 
}