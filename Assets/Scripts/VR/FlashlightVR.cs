using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    private Light flashLight;
    private bool enable = false;

    void Awake()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if(controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                OnInteraction();
            }
            if(controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    public override void OnInteraction()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
