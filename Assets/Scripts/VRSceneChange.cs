using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRSceneChange : MonoBehaviour
{
    public Scenes vrScenes = Scenes.VRTestBed;

    public void ChangeScenes()
    {
        SceneManager.LoadScene(vrScenes.ToString(), LoadSceneMode.Single);
    }

    public void Quit()
    {
        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
