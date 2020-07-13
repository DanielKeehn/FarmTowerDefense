using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // Refrences to all of the UI categories
    private GameObject roundModeUI;
    private GameObject upgradeModeUI;
    private GameObject attackModeUI;
    private GameObject spawnModeUI;
    private GameObject pauseModeUI;
    private GameObject loseModeUI;
    

    private SwitchBetweenAttackAndSpawnMode gameManager;

    
    // Start is called before the first frame update
    void Start()
    {
        try {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenAttackAndSpawnMode>();
            gameManager.switchFromAttackToSpawn += ActivateSpawnModeUI;
            gameManager.switchFromAttackToSpawn += DeactivateAttackModeUI;
            gameManager.switchFromSpawnToAttack += ActivateAttackModeUI;
            gameManager.switchFromSpawnToAttack += DeactivateSpawnModeUI;
        } catch {
            throw new System.ArgumentException("Couldn't Add updateStateUI() Function To Events");
        }

        // Loop Through UI Managers Children And Find Refrences For All UI types
        foreach (Transform child in transform){
            if (child.tag == "RoundModeUI") {
                roundModeUI = child.gameObject;
            }
            if (child.tag == "UpgradeModeUI") {
                upgradeModeUI = child.gameObject;
            }
            if (child.tag == "AttackModeUI") {
                attackModeUI = child.gameObject;
            }
            if (child.tag == "SpawnModeUI") {
                spawnModeUI = child.gameObject;
            }
            if (child.tag == "PauseModeUI") {
                pauseModeUI = child.gameObject;
            }
            if (child.tag == "LoseModeUI") {
                loseModeUI = child.gameObject;
            }
        }
        if (roundModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Round Mode UI");
        }
        if (upgradeModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Upgrade Mode UI");
        }
        if (attackModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Attack Mode UI");
        }
        if (spawnModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Spawn Mode UI");
        }
        if (pauseModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Pause Mode UI");
        }
        if (loseModeUI == null) {
            throw new System.ArgumentException("Couldn't Find Lose Mode UI");
        }
    }

    public void ActivateRoundModeUI() {
        roundModeUI.SetActive(true);
    }

    public void DeactivateRoundModeUI() {
        roundModeUI.SetActive(false);
    }

    public void ActivateUpgradeModeUI() {
        upgradeModeUI.SetActive(true);
    }

    public void DeactivateUpgradeModeUI() {
        upgradeModeUI.SetActive(false);
    }

    public void ActivateAttackModeUI() {
        attackModeUI.SetActive(true);
    }

    public void DeactivateAttackModeUI() {
        attackModeUI.SetActive(false);
    }

    public void ActivateSpawnModeUI() {
        spawnModeUI.SetActive(true);
    }

    public void DeactivateSpawnModeUI() {
        spawnModeUI.SetActive(false);
    }

    public void ActivatePauseModeUI() {
        pauseModeUI.SetActive(true);
    }

    public void DeactivatePauseModeUI() {
        pauseModeUI.SetActive(false);
    }

    public void ActivateLoseModeUI() {
        loseModeUI.SetActive(true);
    }

    public void DeactivateLoseModeUI() {
        loseModeUI.SetActive(false);
    }
}
