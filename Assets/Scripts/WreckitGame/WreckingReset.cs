using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WreckingReset : MonoBehaviour
{
    public Animator buttonAnimator;
    public UnityEvent pressedEvent;
    public UnityEvent releasedEvent;

    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnimator.SetTrigger("Press");

            // invoke the button pressed event
            pressedEvent?.Invoke();

            OnButtonPressed();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnimator.SetTrigger("Release");

            // invoke the button released event
            releasedEvent?.Invoke();
        }
    }
}
