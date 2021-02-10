using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorbeamVR : GrabbableObjectVR
{
    public Transform startingPoint;
    private LineRenderer tractorBeam;
    private RaycastHit hit;
    private Transform hitTransform;
    private Rigidbody hitRigidBody;

    void Awake()
    {
        tractorBeam = GetComponent<LineRenderer>();
    }

    public override void OnUpdatingInteraction()
    {

        if (Physics.Raycast(startingPoint.position, transform.forward, out hit))
        {
            hitTransform = hit.transform;
            hitRigidBody = hitTransform.GetComponent<Rigidbody>();

            tractorBeam.enabled = true;
            tractorBeam.SetPosition(0, startingPoint.position);
            tractorBeam.SetPosition(1, hit.point);

            if(hitRigidBody && !hitRigidBody.isKinematic)
            {
                hitTransform.position = Vector3.Lerp(hitTransform.position, startingPoint.position, Time.deltaTime);
                hitRigidBody.useGravity = false;
            }
            else
            {
                hitTransform = null;
            }
        }
        else
        {
            Drop();
        }
    }
    public override void OnStopInteraction()
    {
        Drop();
    }

    public void Drop()
    {
        tractorBeam.enabled = false;

        if (hitTransform)
        {
            hitRigidBody.useGravity = true;
            hitTransform = null;
            hitRigidBody = null;
        }

    }
}
