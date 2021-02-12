using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingVR : GrabbableObjectVR
{
    private PaintbrushTip paintBrushTip;

    public GameObject paintPrefab;
    private GameObject spawnedPaint;
    
    void Start()
    {
        paintBrushTip = GetComponentInChildren<PaintbrushTip>();
    }

    public override void OnInteraction()
    {
        base.OnInteraction();

        spawnedPaint = Instantiate(paintPrefab, paintBrushTip.transform.position, paintBrushTip.transform.rotation);

        TrailRenderer paintTrail = spawnedPaint.GetComponent<TrailRenderer>();
        paintTrail.GetComponent<Renderer>().material = paintBrushTip.paint;

    }

    public override void OnUpdatingInteraction()
    {
        if (spawnedPaint)
        {
            spawnedPaint.transform.position = paintBrushTip.transform.position;
        }
    }

    public override void OnStopInteraction()
    {
        spawnedPaint.transform.position = paintBrushTip.transform.position;
        spawnedPaint = null;
    }
}
