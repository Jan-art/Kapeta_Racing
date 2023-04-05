using System;
using UnityEngine;

public class DriftCam : MonoBehaviour
{
    [Serializable]
    public class CameraStateOptions
    {
        //Update Camera States
        public bool CamUpdateState;
        public bool CamFixedState = true;
        public bool CamUpdatedLateState;
        public KeyCode switchViewKey = KeyCode.Space;
    }

    public float smoothing = 6.3f;
    public Transform TargetCam;
    public Transform TopView;
    public Transform SideView;
    public CameraStateOptions camerastateOptions;

    bool SideViewOn;

    public static DriftCam instance;

    void Awake()
    {
        instance = this;
    }

    private void FixedUpdate ()
    {
        if(camerastateOptions.CamFixedState)
            UpdateCamera ();
    }

    private void Update ()
    {
        if (Input.GetKey(camerastateOptions.switchViewKey))
            SideViewOn = !SideViewOn;

        if(camerastateOptions.CamUpdateState)
            UpdateCamera ();
    }

    private void LateUpdate ()
    {
        if(camerastateOptions.CamUpdatedLateState)
            UpdateCamera ();
    }

    private void UpdateCamera ()
    {
        if (SideViewOn)
        {
            transform.position = SideView.position;
            transform.rotation = SideView.rotation;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, TopView.position, Time.deltaTime * smoothing);
            transform.LookAt(TargetCam);
        }
    }
}
