using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    // The amount of upgrades left a player can make
    public int upgradesLeft;
    // The UI represnting the amount of upgrades a player has
    public TextMeshProUGUI upgradesLeftUI;

    // The tag representing the caterogry of upgrades currently being viewed
    public string currentUpgradeCategory;

    // The game object storing all of the upgrade categories
    private GameObject upgradePanel;

    // List of tags (strings) representing Upgrade Cateogry Game Objects
    private List<string> upgradeCategoryTags;

    // Reference to SwitchBetweenRoundModeAndUpgradeModeClass
    SwitchBetweenRoundModeandUpgradeMode switchBetweenRoundModeandUpgrade;


    private void Start() {
        // Assign the upgrade panel
        upgradePanel = null;
        foreach(Transform child in transform) {
            if (child.gameObject.tag == "UpgradePanel") {
                upgradePanel = child.gameObject;
            }
        }
        if (upgradePanel == null) {
            throw new System.ArgumentException("Unable to find an upgrade panel");
        }

        // Create List of Upgrade Cateogry Tags
        upgradeCategoryTags = new List<string>();
        foreach(Transform child in upgradePanel.transform) {
            if (child.gameObject.tag == "Untagged") {
                throw new System.ArgumentException("There exists an upgrade catgory without a tag");
            }
            upgradeCategoryTags.Add(child.gameObject.tag); 
            
        }
        if (upgradeCategoryTags == null) {
            throw new System.ArgumentException("Couldn't add any upgrade tags to upgradeCateogoryTags");
        }

        // Assign the upgrade category being viewed
        currentUpgradeCategory = null;
        ChangeCurrentUpgradeCategory(upgradeCategoryTags[0]);

        // Get Switch Between Round and Upgrade Mode Script
        try {
            switchBetweenRoundModeandUpgrade = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenRoundModeandUpgradeMode>();
            if (switchBetweenRoundModeandUpgrade == null) {
                throw new System.ArgumentException("Object found with GameManager tag did not have SwitchBetweenRoundModeandUpgradeMode Script");
            }
        } catch {
            throw new System.ArgumentException("Couldn't Find Game Manager because no object found with GameManager tag");
        }
        
    }

    // Method Changes the Current Upgrade Category Being Looked At
    public void ChangeCurrentUpgradeCategory(string newCurrentUpgradeCategory) {
        if (currentUpgradeCategory != null) {
            HideUpgradeCategory(currentUpgradeCategory);
        }
        ShowUpgradeCateogry(newCurrentUpgradeCategory);
        currentUpgradeCategory = newCurrentUpgradeCategory;
    }

    // Hides the UI when the current upgrade cateogry being viewed changes
    private void HideUpgradeCategory(string upgradeCategory) {
        GameObject currentUpgradeCategoryGameObject = null;
        // Iterate through Upgrade Panel to find tag mathcing game object
        foreach(Transform child in upgradePanel.transform) {
            if (child.gameObject.tag == upgradeCategory) {
                currentUpgradeCategoryGameObject = child.gameObject;
                break;
            }
        }
        if (currentUpgradeCategoryGameObject == null) {
            throw new System.ArgumentException("Couldn't find game object associated with currentUpgradeCateogory tag");
        }
        
        UpgradeCategory currentUpgradeCategoryScript = currentUpgradeCategoryGameObject.GetComponent<UpgradeCategory>();
        currentUpgradeCategoryScript.HideUpgradeAttributes();
    }

     // Shows the UI when the current upgrade cateogry being viewed changes
    private void ShowUpgradeCateogry(string upgradeCategory) {
        GameObject currentUpgradeCategoryGameObject = null;
        // Iterate through Upgrade Panel to find tag mathcing game object
        foreach(Transform child in upgradePanel.transform) {
            if (child.gameObject.tag == upgradeCategory) {
                currentUpgradeCategoryGameObject = child.gameObject;
                break;
            }
        }
        if (currentUpgradeCategoryGameObject == null) {
            throw new System.ArgumentException("Couldn't find game object associated with currentUpgradeCateogory tag");
        }
        
        UpgradeCategory currentUpgradeCategoryScript = currentUpgradeCategoryGameObject.GetComponent<UpgradeCategory>();
        currentUpgradeCategoryScript.ShowUpgradeAttributes();
    }

    // Logic that occurs when the player presses the done button
    public void PressDoneButton() {
        switchBetweenRoundModeandUpgrade.SwitchToRoundMode();
    }
}
