using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GD.MinMaxSlider;

[System.Serializable]
public class Round: MonoBehaviour
{
    // Range that it will take for an enemy to spawn
    [MinMaxSlider(0,4)]
    public Vector2 spawnSpeed;
    // Says if win or lose state occurs
    [HideInInspector]
    public bool winRound;
    [HideInInspector]
    public bool loseRound;

    [System.Serializable]
    public struct EnemyAmount {
        public GameObject enemy;
        [Range(0,100)]
        public int amount;
        public Transform[] spawnLocations;
    }
    
    [Header("Enemies")]
    public EnemyAmount[] enemies;
 }
