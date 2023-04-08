using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Script to stop vehicle controls before countdown is finished
public class VehicleControlON : MonoBehaviour {

  public GameObject vehicleControl;

 void Start () {

       vehicleControl.GetComponent<WheelDriveOption>().enabled = false;
        
 }
 
}