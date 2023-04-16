using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Vehicles.Car;

public class LapCountdown : MonoBehaviour
{
 
  public GameObject ReadySound;
  public GameObject StartSound;
  public GameObject CountdownTimer;
  public GameObject LapTimer;
  public GameObject CarStopON;
  public GameObject GhostKartON;

  public GameObject GreenLight1;
  public GameObject GreenLight2;
  public GameObject GreenLight3;

  public Color orColor = new Color(0.2F, 0.3F, 0.4F);


  public GameObject GreenLight4;
  public GameObject GreenLight5;
  public GameObject GreenLight6;


  void Start()
  {
    StartCoroutine(CountdownStart());
    LapTimer.SetActive(false);
  }
  
  IEnumerator CountdownStart()
  {
    yield return new WaitForSeconds(0.5f);
    CountdownTimer.GetComponent<TMP_Text>().text = "3";
    ReadySound.GetComponent<AudioSource>().Play();
    CountdownTimer.SetActive(true);
    GreenLight6.GetComponent<Renderer>().material.color = orColor;

    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
    CountdownTimer.GetComponent<TMP_Text>().text = "2";
     ReadySound.GetComponent<AudioSource>().Play();
    CountdownTimer.SetActive(true);
    GreenLight5.GetComponent<Renderer>().material.color = orColor;
    
    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
    CountdownTimer.GetComponent<TMP_Text>().text = "1";
    ReadySound.GetComponent<AudioSource>().Play();
    CountdownTimer.SetActive(true);
    GreenLight4.GetComponent<Renderer>().material.color = orColor;

    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
     StartSound.GetComponent<AudioSource>().Play();
     CountdownTimer.GetComponent<TMP_Text>().text = "GO!";
    LapTimer.SetActive(true);
    
    GreenLight1.GetComponent<Renderer>().material.color = Color.green;
    GreenLight2.GetComponent<Renderer>().material.color = Color.green;
    GreenLight3.GetComponent<Renderer>().material.color = Color.green;

    CarStopON. GetComponent<WheelDriveOption>().enabled = true;
    GhostKartON.GetComponent<CarAIControl>().enabled = true;
  }
}
