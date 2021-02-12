using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    private VRInput controller;

    public GameObject collidingObject;              // what we're touching
    public GameObject heldObject;                   // what we're holding

    public bool gripHeld;                           // prevent us from grabbing every frame
    public bool isHeld;                             // object is held

    public float throwForce = 1;

    private GrabbableObjectVR grabbale;
    
    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.gripValue > 0.8 && gripHeld == false)
        {
            gripHeld = true;

            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                // DO THE GRABBING!
                Grab();
                //AdvGrab();
            }
        }

        else if(controller.gripValue < 0.8 && gripHeld == true)
        {
            gripHeld = false;

            if (heldObject)
            {
                // DO THE RELEASE
                Release();
                //AdvRelease();
            }
        }

        if(controller.triggerValue > 0.8f)
        {
            //heldObject.BroadcastMessage("Interact");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    public void Grab()
    {
        Debug.Log("Grabbing!");
        heldObject.transform.SetParent(this.transform);

        heldObject.transform.localPosition = Vector3.zero;

        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        #region Interaction using GetComponent

        grabbale = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbale)
        {
            heldObject.transform.localPosition += grabbale.grabOffset;

            grabbale.isBeingHeld = true;
            grabbale.controller = controller;

            controller.OnTriggerDown.AddListener(grabbale.OnInteraction);
            controller.OnTriggerUpdated.AddListener(grabbale.OnUpdatingInteraction);
            controller.OnTriggerUp.AddListener(grabbale.OnStopInteraction);
        }

        #endregion

    }

    public void Release()
    {
        #region Interaction using GetComponent

        if (grabbale)
        {
            grabbale.isBeingHeld = false;
            grabbale.controller = null;

            controller.OnTriggerDown.RemoveListener(grabbale.OnInteraction);
            controller.OnTriggerUpdated.RemoveListener(grabbale.OnUpdatingInteraction);
            controller.OnTriggerUp.RemoveListener(grabbale.OnStopInteraction);
        }

        #endregion

        // throw!
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.velocity = controller.velocity * throwForce;
        rb.angularVelocity = controller.angularVelocity * throwForce;

        // resetting the held object
        rb.isKinematic = false;
        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    public void AdvGrab()
    {
        // create the fixed joint between the hand and the heldObject
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.connectedBody = heldObject.GetComponent<Rigidbody>();
        fx.breakForce = 100000;
        fx.breakTorque = 100000;

        #region Interaction using GetComponent

        grabbale = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbale)
        {
            heldObject.transform.localPosition += grabbale.grabOffset;

            grabbale.isBeingHeld = true;
            grabbale.controller = controller;

            controller.OnTriggerDown.AddListener(grabbale.OnInteraction);
            controller.OnTriggerUpdated.AddListener(grabbale.OnUpdatingInteraction);
            controller.OnTriggerUp.AddListener(grabbale.OnStopInteraction);

        }

        #endregion

    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            #region Interaction using GetComponent

            if (grabbale)
            {
                grabbale.isBeingHeld = false;
                grabbale.controller = null;

                controller.OnTriggerDown.RemoveListener(grabbale.OnInteraction);
                controller.OnTriggerUpdated.RemoveListener(grabbale.OnUpdatingInteraction);
                controller.OnTriggerUp.RemoveListener(grabbale.OnStopInteraction);
            }

            #endregion

            // break the fixed joint
            Destroy(GetComponent<FixedJoint>());

            // throw!
            Rigidbody rb = heldObject.GetComponent<Rigidbody>();
            rb.velocity = controller.velocity * throwForce;
            rb.angularVelocity = controller.angularVelocity * throwForce;
        }

        heldObject = null;
    }

}
