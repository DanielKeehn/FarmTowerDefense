using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class pauses and resumes the game
public class Pause : MonoBehaviour
{

    // Bool keeping track if the game is paused
    public static bool gamePaused = false;
    

    public void ResumeGame() {
        // Check if the game is already resumed
        if (gamePaused == false) {
            throw new System.ArgumentException("Cannot resume the game because the game is already resumed");
        }
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void PauseGame() {
        // Check if the game is already paused
        if (gamePaused == true) {
            throw new System.ArgumentException("Cannot pause the game because the game is already paused");
        }
        Time.timeScale = 0f;
        gamePaused = true;
    }

}
