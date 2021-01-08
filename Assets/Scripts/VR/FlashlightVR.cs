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
                Interact();
            }
            if(controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    private void Interact()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
