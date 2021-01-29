using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public WreckingReset resetButton;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        // start listening to the Reset button using delegates
        //resetButton.OnButtonPressed += ResetCubes;

        // start listening to the reset button using Events
        resetButton.pressedEvent.AddListener(ResetCubes);
    }


    public void ResetCubes()
    {
        // return cube to its original position and rotation
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;

        // show the cube
        GetComponent<Renderer>().enabled = true;

        // reset the game manager score
        GameManager.instance.numberCubesDestroyed = 0;
        
    }
}
