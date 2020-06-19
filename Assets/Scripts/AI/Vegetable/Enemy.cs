using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : AI
{
    // These are the varaibles all enemies have
    public int spell;
    public bool isUnlocked;
    public bool attacking;
    public GameObject enemyAttacking;

    public RoundManager roundManager;
    Round currentRound; 

}
