using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GrabbableObjectSimHand
{
    public GameObject shootingPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounter;
    //private GrabbableObjectSimHand grabbable;

    private void Awake()
    {
        //grabbable = GetComponent<GrabbableObjectSimHand>();
    }

    void Update()
    {
        #region Enrico Suave controls
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Interact(spawnPoint.position);

            GameObject shot = Instantiate(shootingPrefab, spawnPoint.position, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * shootingForce);

            shotCounter.shotsFired++;
            shotCounter.ShotsFired();

            Destroy(shot, 3f);

        }
        */
        #endregion

        if(isBeingHeld == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        GameObject shot = Instantiate(shootingPrefab, spawnPoint.position, transform.rotation);
        shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * shootingForce);

        shotCounter.shotsFired++;
        shotCounter.ShotsFired();

        Destroy(shot, 3f);
    }
}
