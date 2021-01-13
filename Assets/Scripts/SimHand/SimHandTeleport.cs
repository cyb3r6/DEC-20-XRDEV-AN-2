using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleport : MonoBehaviour
{
    [SerializeField]
    [Tooltip("This is the transform we want to teleport")]
    private Transform simhand;

    private LineRenderer laser;
    private bool shouldTeleport;
    private Vector3 hitPosition;

    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                hitPosition = hit.point;
                laser.SetPosition(0, transform.position);
                laser.SetPosition(1, hitPosition);

                // visuals
                laser.enabled = true;

                shouldTeleport = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            if(shouldTeleport == true)
            {
                // teleport
                simhand.position = hitPosition;

                // visuals
                laser.enabled = false;

                shouldTeleport = false;
            }
        }
    }
}
