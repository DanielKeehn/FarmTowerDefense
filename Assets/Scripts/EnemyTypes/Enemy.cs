using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This the class where all animals derive from the player spawns

public class Enemy : MonoBehaviour
{

    // These are the varaibles all animals have
    public string enemyName;
    public int spell;
    public int costToKill;
    public bool isUnlocked;
    // attack pattern

    // This is the contructor
    public Enemy(string e, int s, int k, bool u)
    {
        this.enemyName = e;
        this.spell = s;
        this.costToKill = k;
        isUnlocked = u;
    }


    // This is the contructor when no variables are given
    public Enemy()
    {
        this.enemyName = "No Name";
        this.spell = 0;
        this.costToKill = 0;
        this.isUnlocked = false;

    }

}