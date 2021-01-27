using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRContinuousMovement : MonoBehaviour
{
    public Transform vrRig;
    public Transform director;

    private VRInput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;

    
    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        playerForward = director.forward;
        playerForward.y = 0f;
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0f;
        playerRight.Normalize();

        vrRig.Translate(playerForward * controller.thumbstick.y * Time.deltaTime, Space.Self);
        vrRig.Translate(playerRight * controller.thumbstick.x * Time.deltaTime, Space.Self);
    }
}
