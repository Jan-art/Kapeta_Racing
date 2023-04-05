// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // Simple Vehicle Audio Controller
// public class VehicleSoundController : MonoBehaviour
// {
//     public float baseAcceleration;
//     public float topAcceleration;
//     private float velocity;

//     private Rigidbody vehicleBody;
//     private AudioSource EngineAudioSource;

//     public float lowTone;
//     public float highTone;
//     private float EngineAudio;

//     void Start()
//     {
//         EngineAudioSource = GetComponent<AudioSource>();
//         vehicleBody = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {
//         EngineSound();
//     }

//     void EngineSound()
//     {
//         velocity = vehicleBody.velocity.magnitude;
//         EngineAudio = vehicleBody.velocity.magnitude / 80f;

//         if(velocity < baseAcceleration)
//         {
//             EngineAudioSource.pitch = lowTone;
//         }

//         if(velocity > baseAcceleration && velocity < topAcceleration)
//         {
//             EngineAudioSource.pitch = lowTone + EngineAudio;
//         }

//         if(velocity > topAcceleration)
//         {
//             EngineAudioSource.pitch = highTone;
//         }
//     }
// }
