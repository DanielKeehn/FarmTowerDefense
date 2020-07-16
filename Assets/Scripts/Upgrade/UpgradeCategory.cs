using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Abstract class for catergoies of upgradable items
public abstract class UpgradeCategory : MonoBehaviour
{
    // A reference to the upgrade manager script
    UpgradeManager upgradeManager;

    private void Start() {
        // Find upgrade manager script
        try {
            upgradeManager = GameObject.FindWithTag("UpgradeModeUI").GetComponent<UpgradeManager>();
            if (upgradeManager == null) {
                throw new System.ArgumentException("Object found with UpgradeModeUI tag did not have UpgradeManager Script");
            }
        } catch {
            throw new System.ArgumentException("Couldn't Find Upgrade Manager because no object found with UpgradeModeUI tag");
        }
    }

    // Shows all of the ui attributes in an upgrade category 
    public void ShowUpgradeAttributes() {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(true);
        }
    }

    // Hides all of the ui attributes in an upgrade category 
    public void HideUpgradeAttributes() {
        foreach(Transform child in transform) {
            child.gameObject.SetActive(false);
        }
    }

    // Method Runs When The Button Associated With This Script is Passed
    public void PressedUpgradeCategoryButton() {
        if (upgradeManager.currentUpgradeCategory == gameObject.tag) {
            Debug.Log("Already on " + gameObject.tag + " upgrade attributes");
        } else {
            upgradeManager.ChangeCurrentUpgradeCategory(gameObject.tag);
        }
    }
}
