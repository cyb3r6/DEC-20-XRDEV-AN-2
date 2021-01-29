using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingTriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WreckingCube")
        {
            GameManager.instance.CountCubesDestory();
            other.GetComponent<Renderer>().enabled = false;
        }
    }
}
