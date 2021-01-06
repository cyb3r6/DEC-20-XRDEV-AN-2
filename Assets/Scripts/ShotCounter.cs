using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text descriptionText;
    public Text testText;
    public int shotsFired;

   
    public void ShotsFired()
    {
        descriptionText.text = "Shots fired: " + shotsFired;
        CountShots(shotsFired);
    }

    public void CountShots(int shots)
    {
        testText.text = "the value of the parameter is: " + shots;
    }

    public void ResetShotsFired()
    {
        shotsFired = 0;
        descriptionText.text = ">_<";
    }

}
