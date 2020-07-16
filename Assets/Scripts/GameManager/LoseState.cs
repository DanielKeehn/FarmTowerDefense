using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class controls when the player enters and exits the lose state and when they press buttons assosiciated with the lose state
public class LoseState : MonoBehaviour
{

    // A reference to the UI manager
    private UIManager uIManager;
    // A reference to game manager
    private GameManager gameManager;

    // A reference to pause script
    private Pause pause;


    // Start is called before the first frame update
    void Start()
    {
        try {
            uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        }
        catch {
            throw new System.ArgumentException("Couldn't Find The UI Manager Script");
        }

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager == null) {
            throw new System.ArgumentException("Couldn't Find The Game Manager Script");
        }

        pause = gameObject.GetComponent<Pause>();
        if (pause == null) {
            throw new System.ArgumentException("Couldn't Find Pause Script");
        } 
    }

    // Method runs when player goes to lose state
    public void GoToLoseState() {
        pause.PauseGame();
        uIManager.DeactivateAttackModeUI();
        uIManager.DeactivateRoundModeUI();
        uIManager.DeactivateSpawnModeUI();
        uIManager.ActivateLoseModeUI();
    }

    // Method occurs when player presses the restart round button
    public void RestartRound() {

    }

    // Method Occurs when player presses the Go To Main Menu button
    public void GoToMainMenu() {
        gameManager.switchToTitleScreen();
    }   
}
