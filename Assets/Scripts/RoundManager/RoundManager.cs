using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    int currentRoundIndex;
    Round currentRound;
    public Round[] rounds;

    UIManager uIManager;
  
    void Start() {
        // currentRoundIndex = 0;
        // currentRound = rounds[currentRoundIndex];
        // uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        // uIManager.updateRound(currentRoundIndex + 1);
        // uIManager.updateEnemiesLeft(currentRound.getNumEnemies());
    }

    // public Round GetCurrentRound() {
    //     return currentRound;
    // }

    // public void goToNextRound() {
    //     currentRoundIndex++;
    //     currentRound = rounds[currentRoundIndex];
    //     uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    //     uIManager.updateEnemiesLeft(currentRound.getNumEnemies());
    //     uIManager.updateRound(currentRoundIndex + 1);
    // }

    //   void Start() {
    //     uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    // }

    // public bool EnemyReadyToSpawn(float currentTime) {
    //     if (currentTime >= this.spawnSpeed) {
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    //  // This method runs when an enemy is killed
    // public void decreaseNumberOfEnemies() {
    //     this.numberOfEnemies--;
    //     uIManager.updateEnemiesLeft(this.numberOfEnemies);
    //     checkWinState();
    // }

    // //This method checks if a round is won by checking how if there are zero enemies left to kill
    // public bool checkWinState() {
    //     if (this.numberOfEnemies <= 0) {
    //         Debug.Log("Round Won!");
    //         RoundManager roundManager = gameObject.GetComponent<RoundManager>();
    //         roundManager.goToNextRound();
    //         return true;
    //     } else {
    //         return false;
    //     }
    // }

    // public int getNumEnemies() {
    //     return this.numberOfEnemies;
    // }

}
