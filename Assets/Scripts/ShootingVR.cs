using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVR : MonoBehaviour
{
    public GameObject shootingPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounter;

    
    void Update()
    {
        
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
