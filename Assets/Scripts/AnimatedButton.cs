using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnimator;
    public UnityEvent pressedEvent;
    public UnityEvent releasedEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonAnimator.SetTrigger("Press");

            // invoke the button pressed event
            pressedEvent?.Invoke();
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
