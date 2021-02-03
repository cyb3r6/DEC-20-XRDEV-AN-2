using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WreckingTriggerZone : MonoBehaviour
{

    public UnityEvent OnCubesDestoryed;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WreckingCube")
        {
            GameManager.instance.CountCubesDestory();
            other.GetComponent<Renderer>().enabled = false;

            OnCubesDestoryed?.Invoke();
        }
    }
}
