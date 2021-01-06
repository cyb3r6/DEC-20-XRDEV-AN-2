using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shootingPrefab;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounter;

    void Update()
    {
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
