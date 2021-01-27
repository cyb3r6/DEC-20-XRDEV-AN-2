using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Vector3 centerOfMass = Vector3.zero;     // (0,0,0)
    public HingeJoint leverJoint;
    private Rigidbody leverRigidbody;
    

    void Start()
    {
        leverRigidbody = GetComponent<Rigidbody>();
        leverRigidbody.centerOfMass = centerOfMass;
    }

    public float NormalizedJointAngle()
    {
        float normalizedAngle = leverJoint.angle / leverJoint.limits.max;
        return normalizedAngle;
    }
}
