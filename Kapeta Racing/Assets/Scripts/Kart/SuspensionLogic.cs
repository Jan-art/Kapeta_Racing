﻿using UnityEngine;
using Photon.Pun;

[ExecuteInEditMode]
public class SuspensionLogic : MonoBehaviour
{
	[Range(0.1f, 20f)]
	[Tooltip("Natural frequency of the suspension springs. Describes bounciness of the suspension.")]
	public float naturalFrequency = 10;

	[Range(0f, 3f)]
	[Tooltip("Damping ratio of the suspension springs. Describes how fast the spring returns back after a bounce. ")]
	public float dampingRatio = 0.8f;

	[Range(-1f, 1f)]
	[Tooltip("The distance along the Y axis the suspension forces application point is offset below the center of mass")]
	public float forceShift = 0.03f;

	[Tooltip("Adjust the length of the suspension springs according to the natural frequency and damping ratio. When off, can cause unrealistic suspension bounce.")]
	public bool setSuspensionDistance = true;

    Rigidbody v_rigb;

    [SerializeField] PhotonView _photonView;

    //========================================================================================================

    void Start ()
    {
        v_rigb = GetComponent<Rigidbody> ();
        
    }
    
	void Update () 
    {
        if (_photonView.IsMine)
        {
            //  Damper parameters based on the better spring model.
            foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>())
            {
                JointSpring spring = wc.suspensionSpring;

                float sqrtWcSprungMass = Mathf.Sqrt(wc.sprungMass);
                spring.spring = sqrtWcSprungMass * naturalFrequency * sqrtWcSprungMass * naturalFrequency;
                spring.damper = 2f * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

                wc.suspensionSpring = spring;

                Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
                float distance = v_rigb.centerOfMass.y - wheelRelativeBody.y + wc.radius;

                wc.forceAppPointDistance = distance - forceShift;
        

                // Make sure the spring force at maximum droop is exactly zero
                if (spring.targetPosition > 0 && setSuspensionDistance)
                    wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
            }
        }
	}

    // Uncomment this to observe how parameters change.
    /*
    void OnGUI()
    {
        foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>()) {
            GUILayout.Label (string.Format("{0} sprung: {1}, k: {2}, d: {3}", wc.name, wc.sprungMass, wc.suspensionSpring.spring, wc.suspensionSpring.damper));
        }

        GUILayout.Label ("Inertia: " + v_rigb.inertiaTensor);
        GUILayout.Label ("Mass: " + v_rigb.mass);
        GUILayout.Label ("Center: " + v_rigb.centerOfMass);
    }
    */
    

}
