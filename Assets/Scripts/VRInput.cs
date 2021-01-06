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



    
    void Awake()
    {
        if (isLeftHand)
        {
            triggerAxis = "LeftTrigger";
            gripAxis = "LeftGrip";
        }
        else
        {
            triggerAxis = "RightTrigger";
            gripAxis = "RightGrip";
        }
    }

    
    void Update()
    {
        triggerValue = Input.GetAxis(triggerAxis);
        gripValue = Input.GetAxis(gripAxis);

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngluarRotation) / Time.deltaTime;
        previousAngluarRotation = this.transform.eulerAngles;
    }
}
