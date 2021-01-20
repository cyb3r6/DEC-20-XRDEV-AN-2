using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class VRTeleport : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the transform we want to teleport")]
    private Transform vrRig;

    private VRInput controller;
    private LineRenderer laser;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    void Start()
    {
        controller = GetComponent<VRInput>();
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetButton(controller.thumbstickButton))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hitPosition = hit.point;
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, hitPosition);

                // visuals
                laser.enabled = true;

                shouldTeleport = true;
            }
        }

        if (Input.GetButtonUp(controller.thumbstickButton))
        {
            if (shouldTeleport == true)
            {
                // teleport
                vrRig.position = hitPosition;

                // visuals
                laser.enabled = false;

                shouldTeleport = false;
            }
        }
    }


}
