using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRInput : MonoBehaviour
{
    public Hands hand = Hands.Left;

    public float triggerValue;
    public float gripValue;

    public Vector2 thumbstick;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUpdated;
    public UnityEvent OnTriggerUp;
    public UnityEvent OnGripDown;
    public UnityEvent OnThumbstickDown;
    public UnityEvent OnThumbstickUp;

    private Vector3 previousPosition;
    private Vector3 previousAngluarRotation;

    private string triggerAxis;
    private string gripAxis;
    private string thumbstickX;
    private string thumbstickY;
    private string triggerButton;
    private string gripButton;
    private string thumbstickButton;
    

    
    void Awake()
    {
        triggerAxis = $"{hand}Trigger";
        gripAxis = $"{hand}Grip";
        triggerButton = $"{hand}TriggerButton";
        gripButton = $"{hand}GripButton";
        thumbstickButton = $"{hand}ThumbstickButton";
        thumbstickX = $"{hand}ThumbstickX";
        thumbstickY = $"{hand}ThumbstickY";
       
    }


    void Update()
    {
        triggerValue = Input.GetAxis(triggerAxis);
        gripValue = Input.GetAxis(gripAxis);

        thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));

        if (Input.GetButtonDown(triggerButton))
        {
            OnTriggerDown?.Invoke();
        }
        if (Input.GetButton(triggerButton))
        {
            OnTriggerUpdated?.Invoke();
        }

        if (Input.GetButtonUp(triggerButton))
        {
            OnTriggerUp?.Invoke();
        }
        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
        }

        if (Input.GetButtonUp(gripButton))
        {
            // do some stuff there
        }

        if (Input.GetButtonDown(thumbstickButton))
        {
            OnThumbstickDown?.Invoke();
        }

        if (Input.GetButtonUp(thumbstickButton))
        {
            OnThumbstickUp?.Invoke();
        }

        velocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        angularVelocity = (this.transform.eulerAngles - previousAngluarRotation) / Time.deltaTime;
        previousAngluarRotation = this.transform.eulerAngles;
    }
}
