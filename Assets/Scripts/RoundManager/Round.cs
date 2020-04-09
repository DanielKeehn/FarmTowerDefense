using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    
    // The number this round will appear
    public int roundNumber;
    //Variables for a round
    public int numberOfEnemies;
    // This can be changed to a Random value
    public int spawnSpeed;

    public Round(int ne, int ss, int rn) {
        this.numberOfEnemies = ne;
        this.spawnSpeed = ss;
        this.roundNumber = rn;
    }

    public Round() {
        this.numberOfEnemies = 0;
        this.spawnSpeed = 0;
        this.roundNumber = 0;
    }
}
