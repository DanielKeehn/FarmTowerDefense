using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void switchToMainGame() {
        Debug.Log("LoadingMainScene");
        SceneManager.LoadScene("MainScene");
    }

    public void switchToTitleScreen() {
        Debug.Log("LoadingTitleScreen");
        SceneManager.LoadScene("TitleScreen_New");
    }

}
