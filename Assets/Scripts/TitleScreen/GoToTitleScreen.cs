using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoToTitleScreen : MonoBehaviour
{

    public PlayableDirector playableDirector;
    public Camera cutsceneCamera;
    public Camera titleScreenCamera;


    // Update is called once per frame
    void Update()
    {
        // Checks if the cutscene is over
        if (playableDirector.time >= 45.0) {
            // Deactivates cutscene camera and activates title screen camera here
            titleScreenCamera.gameObject.SetActive(true);
            cutsceneCamera.gameObject.SetActive(false);
        }       
    }
}
