using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    
    // The number this round will appear
    public int roundNumber;
    //Variables for a round
    public int numberOfEnemies;
    // This can be changed to a range, but is currently the set time it takes for one enemy to spawn
    public int spawnSpeed;
    // Says if win or lose state occurs
    public bool winRound;
    public bool loseRound;

    public Round(int ne, int ss, int rn) {
        this.numberOfEnemies = ne;
        this.spawnSpeed = ss;
        this.roundNumber = rn;
        this.winRound = false;
        this.loseRound = false;
    }

    public Round() {
        this.numberOfEnemies = 0;
        this.spawnSpeed = 0;
        this.roundNumber = 0;
        this.winRound = false;
        this.loseRound = false;
    }

    public bool EnemyReadyToSpawn(float currentTime) {
        if (currentTime >= this.spawnSpeed) {
            return true;
        } else {
            return false;
        }
    }

     // This method runs when an enemy is killed
    public void decreaseNumberOfEnemies() {
        this.numberOfEnemies--;
        checkWinState();
    }

    //This method checks if a round is won by checking how if there are zero enemies left to kill
    public bool checkWinState() {
        if (this.numberOfEnemies <= 0) {
            Debug.Log("Round Won!");
            return true;
        } else {
            return false;
        }
    }
}
