using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    int currentRoundIndex;
    private Round currentRound;
    public Round[] rounds;
    private int numberOfEnemies;

    UIManager uIManager;

    SwitchBetweenRoundModeandUpgradeMode switchBetweenRoundModeandUpgradeMode;
  
    void Awake() {
        rounds = gameObject.GetComponents<Round>();
        currentRoundIndex = 0;
        currentRound = rounds[currentRoundIndex];
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        getNumberOfEnemies();
        uIManager.updateRound(currentRoundIndex + 1);
        uIManager.updateEnemiesLeft(numberOfEnemies);
    }

    private void Start() {
        switchBetweenRoundModeandUpgradeMode = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenRoundModeandUpgradeMode>();
        if (switchBetweenRoundModeandUpgradeMode == null) {
            throw new System.ArgumentException("Couldn't find reference to SwitchBetweenRoundModeandUpgradeMode script. Make sure SwitchBetweenRoundModeandUpgradeMode component is inside the game manager");
        }
    }
    private void goToNextRound() {  
        currentRoundIndex++;
        currentRound = rounds[currentRoundIndex];
        uIManager.updateEnemiesLeft(numberOfEnemies);
        uIManager.updateRound(currentRoundIndex + 1);
    }

     // This method runs when an enemy is killed
    public void decreaseNumberOfEnemies() {
        numberOfEnemies--;
        uIManager.updateEnemiesLeft(numberOfEnemies);
        checkWinState();
    }

    //This method checks if a round is won by checking how if there are zero enemies left to kill
    private void checkWinState() {
        if (this.numberOfEnemies <= 0) {
            Debug.Log("Round Won!");
            switchBetweenRoundModeandUpgradeMode.SwitchToUpgradeMode();
        }
    }

    // When a new round starts, calculate this number to find out how many enemies can be spawned
    private void getNumberOfEnemies() {
        Round.EnemyAmount[] enemies = currentRound.enemies;
        foreach (Round.EnemyAmount enemy in enemies) {
            numberOfEnemies += enemy.amount;
        }
    }

    public Round GetCurrentRound() {
        return currentRound;
    }

}
