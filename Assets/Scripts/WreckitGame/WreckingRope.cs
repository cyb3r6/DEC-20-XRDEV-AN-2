using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingRope : MonoBehaviour
{
    public Transform wreckingBall;
    private LineRenderer rope;

    void Start()
    {
        rope = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        rope.SetPosition(0, this.transform.position);
        rope.SetPosition(1, wreckingBall.position);
    }
}
