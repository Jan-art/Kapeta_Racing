using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapCountdown : MonoBehaviour
{
 
  public GameObject ReadySound;
  public GameObject StartSound;
  public GameObject CountdownTimer;
  public GameObject LapTimer;
  public GameObject CarStopON;

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
    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
    CountdownTimer.GetComponent<TMP_Text>().text = "2";
     ReadySound.GetComponent<AudioSource>().Play();
    CountdownTimer.SetActive(true);
    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
    CountdownTimer.GetComponent<TMP_Text>().text = "1";
    ReadySound.GetComponent<AudioSource>().Play();
    CountdownTimer.SetActive(true);
    yield return new WaitForSeconds(1);
    CountdownTimer.SetActive(false);
     StartSound.GetComponent<AudioSource>().Play();
    LapTimer.SetActive(true);
    CarStopON. GetComponent<WheelDriveOption>().enabled = true;
  }
}
