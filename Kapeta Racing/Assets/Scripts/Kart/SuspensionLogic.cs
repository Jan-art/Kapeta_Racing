using UnityEngine;
//using Photon.Pun;

// ========================================================================================================
[ExecuteInEditMode]
public class SuspensionLogic : MonoBehaviour
{
	[Range(0.1f, 20f)]
	[Tooltip("Bounciness of the suspension.")]
	public float suspensionRatio = 10;

	[Range(0f, 3f)]
	[Tooltip("How fast the spring returns back after a bounce. ")]
	public float dampRatio = 0.8f;

	[Range(-1f, 1f)]
	[Tooltip("The distance along the Y axis the suspension forces application point is offset below the center of mass")]
	public float shiftForce = 0.03f;

	[Tooltip("Adjust the length of the suspension springs according to suspensionRatio & dampingRatio.")]
	public bool suspensionAdj = true;

    Rigidbody v_rigb;

    //[SerializeField] PhotonView _photonView;

    //========================================================================================================

    void Start ()
    {
        v_rigb = GetComponent<Rigidbody> ();
        
    }
    
	void Update () 
    {
        //if (_photonView.IsMine)
        {
            //  Damper parameters based on the better spring model.
            foreach (WheelCollider wc in GetComponentsInChildren<WheelCollider>())
            {
                //WheelCollider "wc.suspensionSpring" property within Unity is a struct that contains the spring and damper values.
                JointSpring spring = wc.suspensionSpring;

                float sqrtWcSprungMass = Mathf.Sqrt(wc.sprungMass);
                spring.spring = sqrtWcSprungMass * suspensionRatio * sqrtWcSprungMass * suspensionRatio;
                spring.damper = 2f * dampRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

                wc.suspensionSpring = spring;

                Vector3 wheelRelativeBody = transform.InverseTransformPoint(wc.transform.position);
                float distance = v_rigb.centerOfMass.y - wheelRelativeBody.y + wc.radius;

                wc.forceAppPointDistance = distance - shiftForce;
        

                // Ensures spring force is not greater than gravity.
                if (spring.targetPosition > 0 && suspensionAdj)
                    wc.suspensionDistance = wc.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
            }
        }
	}
}
