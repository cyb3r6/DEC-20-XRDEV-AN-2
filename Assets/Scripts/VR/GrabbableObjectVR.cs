using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectVR : MonoBehaviour
{
    public bool isBeingHeld;
    public VRInput controller;

    public Vector3 grabOffset;
    

    public virtual void OnInteraction() 
    {
        Debug.Log("Base OnInteraction has been called");
    }

    public virtual void OnUpdatingInteraction()
    {
        
    }

    public virtual void OnStopInteraction() 
    {
        
    }

}
