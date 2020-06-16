using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundManager : MonoBehaviour
{
    int currentRoundIndex;
    private Round currentRound;
    public Round[] rounds;
    private int numberOfEnemies;

    public TextMeshProUGUI enemiesLeftUI;
    public TextMeshProUGUI currentRoundUI;

    // A reference to the enemy spawner
    private EnemySpawner enemySpawner;
    
    SwitchBetweenRoundModeandUpgradeMode switchBetweenRoundModeandUpgradeMode;
  
    void Awake() {
        rounds = gameObject.GetComponents<Round>();
        currentRoundIndex = 0;
        currentRound = rounds[currentRoundIndex];
        getNumberOfEnemies();
    }

    private void Start() {
        switchBetweenRoundModeandUpgradeMode = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenRoundModeandUpgradeMode>();
        if (switchBetweenRoundModeandUpgradeMode == null) {
            throw new System.ArgumentException("Couldn't find reference to SwitchBetweenRoundModeandUpgradeMode script. Make sure SwitchBetweenRoundModeandUpgradeMode component is inside the game manager");
        }
        try {
            enemySpawner = gameObject.GetComponent<EnemySpawner>();
        } catch {
            throw new System.ArgumentException("Couldn't find enemy spawner");
        }
        enemiesLeftUI.text = numberOfEnemies.ToString(); 
        currentRoundUI.text = (currentRoundIndex + 1).ToString();
    }
    private void goToNextRound() {  
        currentRoundIndex++;
        try {
            currentRound = rounds[currentRoundIndex];
            getNumberOfEnemies();
            enemySpawner.ResetEnemySpanwer();
            enemiesLeftUI.text = numberOfEnemies.ToString(); 
            currentRoundUI.text = (currentRoundIndex + 1).ToString();
        } catch {
            Debug.Log("YOU WIN!!!!!");
        }
    }

     // This method runs when an enemy is killed
    public void decreaseNumberOfEnemies() {
        numberOfEnemies--;
        enemiesLeftUI.text = numberOfEnemies.ToString();
        checkWinState();
    }

    //This method checks if a round is won by checking how if there are zero enemies left to kill
    private void checkWinState() {
        if (this.numberOfEnemies <= 0) {
            Debug.Log("Round Won!");
            goToNextRound();
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
