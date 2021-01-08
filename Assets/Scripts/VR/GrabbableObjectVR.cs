using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObjectVR : MonoBehaviour
{
    public bool isBeingHeld;
    public VRInput controller;

    public virtual void Interact() { }

}
