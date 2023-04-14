using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_GPS : MonoBehaviour
{
   public GameObject GPS;
   public GameObject[] WayPoints = new GameObject[36];
   public int GPSTracker;

    
    void Update()
    {
        if (GPSTracker < WayPoints.Length)
        {
            GPS.transform.position = WayPoints[GPSTracker].transform.position;
        }
        else
        {
            GPSTracker = 0;
        }

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GhostKart01")
        {
           this.GetComponent<BoxCollider>().enabled = false;
              GPSTracker+=1;
              if (GPSTracker < WayPoints.Length)
              {
                  yield return new WaitForSeconds(1);
                  this.GetComponent<BoxCollider>().enabled = true;
              }

              
        }
    }
}
