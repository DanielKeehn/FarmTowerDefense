using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class pauses and resumes the game
public class Pause : MonoBehaviour
{

    // Bool keeping track if the game is paused
    public static bool gamePaused = false;

    // A reference to the UI manager
    private UIManager uIManager;

    // Get a reference to the UI manager
    private void Start() {
        try {
            uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        }
        catch {
            throw new System.ArgumentException("Couldn't Find The UI Manager Script");
        }  
    }
    

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

    // Pauses or resumes the game based on the game paused boolean
    private void PauseOrResume() {
        if (gamePaused == false) {
            PauseGame();
            uIManager.ActivatePauseModeUI();
        } else {
            ResumeGame();
            uIManager.DeactivatePauseModeUI();
        }
    }

    // Checks if the player presses the input to enter or exit the pause menu
    private bool PressedPause() {
        if (Input.GetButtonDown("Pause")) {
            return true;
        } else {
            return false;
        }
    }


    private void Update() {
        if (PressedPause() == true) {
            PauseOrResume();
        }
    }

}
