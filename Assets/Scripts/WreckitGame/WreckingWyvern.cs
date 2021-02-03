using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingWyvern : MonoBehaviour
{
    public Lever forwardLever, rightLever;
    public float speed;
    public float rotationSpeed;
    public float deadZone = 0.05f;
    
    void Update()
    {
        if(Mathf.Abs(forwardLever.NormalizedJointAngle()) > deadZone)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardLever.NormalizedJointAngle();
        }

        if (Mathf.Abs(rightLever.NormalizedJointAngle()) > deadZone)
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLever.NormalizedJointAngle();
        }
    }
}
