using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class determines all the spawn points that an enemy can spawn to

public class SpawnPoints : MonoBehaviour
{

    public Transform[] spawnLocations;
    public EnemyManager enemyManager;

    void spawnEnemy(string name) {
        Dictionary<string, GameObject> enemyDict = enemyManager.enemyDict;
        Transform randSpawnLocation = spawnLocations[Random.Range(0,spawnLocations.Length)];
    }   
}
