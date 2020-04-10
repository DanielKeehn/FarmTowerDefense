using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    int currentRoundIndex;
    Round currentRound;
    public Round[] rounds;
  
    void Start() {
        currentRoundIndex = 0;
        currentRound = rounds[currentRoundIndex];
    }

    public Round GetCurrentRound() {
        return currentRound;
    }

    public void goToNextRound() {
        currentRoundIndex++;
        currentRound = rounds[currentRoundIndex];
    }

}
