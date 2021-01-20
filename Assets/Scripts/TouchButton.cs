using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 originalPosition;
    public Transform down;
    public Transform button;
    
    void Start()
    {
        originalPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = down.position;
            audioSource.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = originalPosition;
        }
    }
}
