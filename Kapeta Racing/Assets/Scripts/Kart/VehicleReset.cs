using UnityEngine;
using System.Collections.Generic;

//RESET VEHICLE IF UPSIDEDOWN
public class VehicleReset : MonoBehaviour
{
	public GameObject vehicle;
	public Transform spawnlocation;

	private DriftCam v_DriftCam;
	private int m_VehicleId;

	public static VehicleReset instance;

	void Awake()
    {
		instance = this;
    }

	void Start () 
    {
		v_DriftCam = GetComponent<DriftCam>();
	}
	
	void Update () 
    {
    // Input Key
		if (Input.GetKeyDown(KeyCode.R))
		{
			Transform vehicleTransform = vehicle.transform;
			vehicleTransform.rotation = Quaternion.identity;

			Transform closest = spawnlocation.GetChild(0);

			// Find the closest spawn point.
			for (int i = 0; i < spawnlocation.childCount; ++i)
			{
				Transform thisTransform = spawnlocation.GetChild(i);

				float distanceToClosest = Vector3.Distance(closest.position, vehicleTransform.position);
				float distanceToThis = Vector3.Distance(thisTransform.position, vehicleTransform.position);

				if (distanceToThis < distanceToClosest)
				{
					closest = thisTransform;
				}
			}

			// Spawn
     #if UNITY_EDITOR
			Debug.Log("Teleporting to " + closest.name);
     #endif
			vehicleTransform.rotation = closest.rotation;

			var renderer = vehicleTransform.gameObject.GetComponentInChildren<MeshRenderer>();
      
			var wheel = vehicleTransform.gameObject.GetComponentInChildren<WheelCollider>(); 

			RaycastHit hit;
      // Boxcast
			if (Physics.BoxCast(closest.position, renderer.bounds.extents, Vector3.down, out hit, vehicleTransform.rotation, float.MaxValue, ~(1 << LayerMask.NameToLayer("Car"))) )
			{
				vehicleTransform.position = closest.position + Vector3.down * (hit.distance - wheel.radius);
			}
			else
			{
				Debug.Log("Failed to locate the ground below the spawn point " + closest.name);
				vehicleTransform.position = closest.position;
			}

			// Velocity Reset
			var vehicleBody = vehicleTransform.gameObject.GetComponent<Rigidbody>();
			vehicleBody.velocity = Vector3.zero;
			vehicleBody.angularVelocity = Vector3.zero;
		}
	}
}
