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
        currentRoundIndex = 0;
        currentRound = rounds[currentRoundIndex];
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uIManager.updateRound(currentRoundIndex + 1);
        uIManager.updateEnemiesLeft(currentRound.getNumEnemies());
    }

    public Round GetCurrentRound() {
        return currentRound;
    }

    public void goToNextRound() {
        currentRoundIndex++;
        currentRound = rounds[currentRoundIndex];
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        uIManager.updateEnemiesLeft(currentRound.getNumEnemies());
        uIManager.updateRound(currentRoundIndex + 1);
    }

}
