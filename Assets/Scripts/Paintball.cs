using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public List<Material> paintballPaints;

    private static int paintIndex = 0;

    private void Start()
    {
        Debug.Log("the number of paints in paintballPaints is: " + paintballPaints.Count);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Paintable")
        {
            collision.collider.GetComponent<Renderer>().material = paintballPaints[paintIndex];

            paintIndex++;   // paintIndex + 1

            if(paintIndex == paintballPaints.Count)
            {
                paintIndex = 0;
            }
        }
    }
}
