﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class determines all the spawn points that an enemy can spawn to and spawns the enemies by looking at the data for the current round

public class SpawnPoints : MonoBehaviour
{

    public Transform[] spawnLocations;
    public EnemyManager enemyManager;

    public RoundManager roundManager;
    Round currentRound; 

    float spawnTimer;

    ArrayList spawnedEnemiesArray = new ArrayList();

    void Start()
    {
        spawnTimer = 0.0f;
    }

    public void Update()
    {
        spawnTimer += Time.deltaTime;
        currentRound = roundManager.GetCurrentRound();
        if (currentRound.EnemyReadyToSpawn(spawnTimer)) {
            spawnTimer = 0.0f;
            spawnEnemy("Carrot");
        }
    }

    void spawnEnemy(string name) {
        Dictionary<string, GameObject> enemyDict = enemyManager.enemyDict;
        GameObject enemyPrefab = enemyDict[name];

        Transform spawnLocation = spawnLocations[Random.Range(0,spawnLocations.Length)];
        
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnLocation);
        spawnedEnemy.SetActive(true);

        spawnedEnemiesArray.Add(spawnedEnemy);
    }

    public ArrayList getSpawnedEnemiesArray() {
        return spawnedEnemiesArray;
    }   
}