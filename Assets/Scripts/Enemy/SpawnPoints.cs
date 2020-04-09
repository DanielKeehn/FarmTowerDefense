using System.Collections;
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

    void Start()
    {
        spawnTimer = 0.0f;
        currentRound = roundManager.GetCurrentRound();
    }

    public void Update()
    {
        spawnTimer += Time.deltaTime;
        if (currentRound.EnemyReadyToSpawn(spawnTimer)) {
            spawnTimer = 0.0f;
            spawnEnemy("Carrot");
        }
    }

    void spawnEnemy(string name) {
        Dictionary<string, GameObject> enemyDict = enemyManager.enemyDict;
        Transform randSpawnLocation = spawnLocations[Random.Range(0,spawnLocations.Length)];
    }   
}
