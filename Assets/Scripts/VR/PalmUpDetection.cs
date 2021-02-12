using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PalmUpDetection : MonoBehaviour
{
    public Transform palm;

    public UnityEvent onPalmUp;
    public UnityEvent onPalmDown;

    private void Update()
    {
        if (IsPalmFacingCamera())
        {
            onPalmUp?.Invoke();
        }
        else
        {
            onPalmDown?.Invoke();
        }
    }

    private bool IsPalmFacingCamera()
    {
        if(Vector3.Dot(palm.up, Camera.main.transform.forward) > 0f)
        {
            return true;
        }
        return false;
    }
}