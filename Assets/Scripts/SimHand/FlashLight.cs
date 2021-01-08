using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : GrabbableObjectSimHand
{
    private Light flashLight;
    
    void Awake()
    {
        flashLight = GetComponentInChildren<Light>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
