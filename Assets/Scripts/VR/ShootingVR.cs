using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVR : GrabbableObjectVR
{
    public GameObject shootingPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounter;
    private bool enable;
    
    void Update()
    {
        if (isBeingHeld)
        {
            if (controller.triggerValue > 0.8f && !enable)
            {
                enable = true;
                Interact();
            }
            if (controller.triggerValue < 0.8f && enable)
            {
                enable = false;
            }
        }
    }

    public override void Interact()
    {
        GameObject shot = Instantiate(shootingPrefab, spawnPoint.position, transform.rotation);
        shot.GetComponent<Rigidbody>().AddForce(shot.transform.forward * shootingForce);

        shotCounter.shotsFired++;
        shotCounter.ShotsFired();

        Destroy(shot, 3f);
    }
}
