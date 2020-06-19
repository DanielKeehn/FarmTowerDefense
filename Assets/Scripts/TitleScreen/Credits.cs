using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

    public GameObject creditsUI;
    public GameObject titleScreenUI;

    public void goToCredits() {
        titleScreenUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void ExitCredits() {
        titleScreenUI.SetActive(true);
        creditsUI.SetActive(false);
    }
}
