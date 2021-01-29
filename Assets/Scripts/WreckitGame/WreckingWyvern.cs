using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingWyvern : MonoBehaviour
{
    public Lever forwardLever;
    public float speed;
    public float rotationSpeed;

    
    void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardLever.NormalizedJointAngle();
    }
}
