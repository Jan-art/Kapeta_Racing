using System;
using UnityEngine;

public class DriftCam : MonoBehaviour
{
    [Serializable]
    public class AdvancedOptions
    {
        public bool updateCameraInUpdate;
        public bool updateCameraInFixedUpdate = true;
        public bool updateCameraInLateUpdate;
        public KeyCode switchViewKey = KeyCode.Space;
    }

    public float smoothing = 6f;
    public Transform TargetCam;
    public Transform TopView;
    public Transform SideView;
    public AdvancedOptions advancedOptions;

    bool m_ShowingSideView;

    public static DriftCam instance;

    void Awake()
    {
        instance = this;
    }

    private void FixedUpdate ()
    {
        if(advancedOptions.updateCameraInFixedUpdate)
            UpdateCamera ();
    }

    private void Update ()
    {
        if (Input.GetKey(advancedOptions.switchViewKey))
            m_ShowingSideView = !m_ShowingSideView;

        if(advancedOptions.updateCameraInUpdate)
            UpdateCamera ();
    }

    private void LateUpdate ()
    {
        if(advancedOptions.updateCameraInLateUpdate)
            UpdateCamera ();
    }

    private void UpdateCamera ()
    {
        if (m_ShowingSideView)
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
