using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCrash : MonoBehaviour
{
    public AudioSource CrashSound;


    void Start()
    {
        CrashSound.GetComponent<AudioSource>().Stop();
    }
    void update()
    {
        CrashSound = GetComponent<AudioSource>();
    }

 void OnCollisionEnter(Collision collision){
   if (collision.relativeVelocity.magnitude > 2)
            CrashSound.Stop();
            CrashSound.Play();
            
          Debug.Log("PLayed Crash Sound!");


  }


}

