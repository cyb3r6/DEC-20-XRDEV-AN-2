using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerZone : MonoBehaviour
{
    public Animator bridgeAnim;
    public string animatorTrigger;

    private void OnTriggerEnter(Collider other)
    {
        bridgeAnim.SetTrigger(animatorTrigger);
    }
}
