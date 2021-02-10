using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRUIRaycaster : MonoBehaviour
{
    [SerializeField]
    private Transform director;

    [SerializeField]
    private LineRenderer uiLine;

    [SerializeField]
    private float maxDistance = 10f;

    public int layerMask;

    private VRInput controller;

    private Button button;

    
    void Awake()
    {
        controller = GetComponent<VRInput>();
        controller.OnTriggerDown.AddListener(VRButtonClick);

        // shifting the layermaks from 
        // 00000000 to 
        // 00010000
        layerMask = 1 << 5;
    }

    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(controller.transform.position, director.forward, out hit, maxDistance, layerMask))
        {
            uiLine.enabled = true;
            uiLine.SetPosition(0, controller.transform.position);
            uiLine.SetPosition(1, hit.point);

            button = hit.transform.GetComponent<Button>();
        }
        else
        {
            uiLine.enabled = false;
            button = null;
        }
    }

    public void VRButtonClick()
    {
        if (button)
        {
            button.onClick.Invoke();
        }
    }
}
