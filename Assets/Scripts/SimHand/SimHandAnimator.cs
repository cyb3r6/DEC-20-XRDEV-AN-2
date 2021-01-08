using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimator : MonoBehaviour
{
    private Animator simhandAnimator;

   
    void Awake()
    {
        simhandAnimator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            simhandAnimator.SetBool("IsClosing", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            simhandAnimator.SetBool("IsClosing", false);
        }
    }
}
