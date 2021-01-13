using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;     // if true, this is on the left hand

    public float triggerValue;
    public float gripValue;
    

    public Vector3 velocity;
    public Vector3 angularVelocity;

    private Vector3 previousPosition;
    private Vector3 previousAngluarRotation;

    private string triggerAxis;
    private string gripAxis;
    public string triggerButton;
    public string gripButton;
    public string thumbstickButton;

    
    void Awake()
    {
        if (isLeftHand)
        {
            triggerAxis = "LeftTrigger";
            gripAxis = "LeftGrip";
            triggerButton = "LeftTriggerButton";
            gripButton = "LeftGripButton";
            thumbstickButton = "LeftThumbstickButton";
        }
        else
        {
            triggerAxis = "RightTrigger";
            gripAxis = "RightGrip";
            triggerButton = "RightTriggerButton";
            gripButton = "RightGripButton";
            thumbstickButton = "RightThumbstickButton";
        }
    }

    
    void Update()
    {
        triggerValue = Input.GetAxis(triggerAxis);
        gripValue = Input.GetAxis(gripAxis);

        if (Input.GetButtonDown(triggerButton))
        {
            // do some stuff here
        }

        if (Input.GetButtonUp(triggerButton))
        {
            // do some stuff there
        }

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngluarRotation) / Time.deltaTime;
        previousAngluarRotation = this.transform.eulerAngles;
    }
}
