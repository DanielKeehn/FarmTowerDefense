using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls Actions When The Player Switches To Round Mode or Upgrade Mode

public class SwitchBetweenRoundModeandUpgradeMode : MonoBehaviour
{

    // A reference to the pause script
    Pause pauseScript;

    // A reference to UI Manager
    UIManager uIManager;

    private void Start() {
        pauseScript = gameObject.GetComponent<Pause>();
        if (pauseScript == null) {
            throw new System.ArgumentException("Couldn't find reference to pause script. Make sure this component and a pause script is inside the game manager");
        }
        try {
            uIManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
        } catch {
            throw new System.ArgumentException("Couldn't find UI Manager, make sure you have a UI Manager Object with tag and UI Manager Script");
        }   
    }

    // Actions That Occur When A Player Switches To Upgrade Mode
    public void SwitchToUpgradeMode() {
        pauseScript.PauseGame();
        uIManager.ActivateUpgradeModeUI();
        uIManager.DeactivateAttackModeUI();
        uIManager.DeactivateRoundModeUI();
        uIManager.DeactivateSpawnModeUI();
        // This reactivates the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    // Actions That Occur When A Player Switches To Round Mode
    public void SwitchToRoundMode() {
        pauseScript.ResumeGame();        
    }
}
