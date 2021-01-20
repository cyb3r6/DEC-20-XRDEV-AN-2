using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text descriptionText;
    public Text testText;
    public int shotsFired;
    private AudioSource canvasAudioSource;

    private void Start()
    {
        canvasAudioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        Debug.Log("click");
        canvasAudioSource.Play();
    }

    public void StopMusic()
    {
        canvasAudioSource.Pause();
    }

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
