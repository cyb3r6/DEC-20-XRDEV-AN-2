using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public WreckingReset resetButton;
    public float pitchFactor = 4f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody cubeRigidbody;
    private AudioSource cubeAudio;

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        // start listening to the Reset button using delegates
        resetButton.OnButtonPressed += ResetCubes;

        // start listening to the reset button using Events
        //resetButton.pressedEvent.AddListener(ResetCubes);

        cubeRigidbody = GetComponent<Rigidbody>();
        cubeAudio = GetComponent<AudioSource>();
    }


    public void ResetCubes()
    {
        // return cube to its original position and rotation
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;

        // show the cube
        GetComponent<Renderer>().enabled = true;

        // stop the cubes inertia
        cubeRigidbody.velocity = Vector3.zero;
        cubeRigidbody.angularVelocity = Vector3.zero;

        // reset the game manager score
        GameManager.instance.numberCubesDestroyed = 0;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "WreckingBall")
        {
            if(collision.relativeVelocity.magnitude > 2f)
            {
                Debug.Log($"The impact velocity is {collision.relativeVelocity.magnitude} which is huge");

                cubeAudio.pitch = 1f + collision.relativeVelocity.magnitude / pitchFactor;

                cubeAudio.volume = collision.relativeVelocity.magnitude / pitchFactor;

                cubeAudio.Play();
            }
        }
    }
}
