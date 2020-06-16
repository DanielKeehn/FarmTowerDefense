using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class determines all the spawn points that an enemy can spawn to and spawns the enemies by looking at the data for the current round

public class EnemySpawner : MonoBehaviour
{

    private RoundManager roundManager;
    private float spawnTimer;
    private List<GameObject> vegetableList;
    private float spawnSpeed;
    private bool enemiesAllSpawned;

    void Start()
    {
        roundManager = gameObject.GetComponent<RoundManager>();
        if (roundManager == null) {
            throw new System.ArgumentException("Couldn't find Round Manger. Put Round Manger component in Round Manager Object");
        }
        try {
            vegetableList = GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>().vegetableList;
        }
        catch {
            throw new System.ArgumentException("Couldn't find Vegetable List. Make sure there exists a Game Object with the game object tag and a current attackable objects script is a component of the game manager");
        }
        spawnTimer = 0.0f;
        enemiesAllSpawned = false;
        getSpawnSpeed();
    }

    void Update()
    {
        if (!enemiesAllSpawned) {
            spawnTimer += Time.deltaTime;
            getSpawnSpeed();
            if (EnemyReadyToSpawn(spawnTimer)) {
                spawnVegetable();
                getSpawnSpeed();
                spawnTimer = 0.0f;
            }
        }
    }

    // Run this function when a new round starts to reset values for spawning logic
    public void ResetEnemySpanwer() {
        spawnTimer = 0.0f;
        enemiesAllSpawned = false;
        getSpawnSpeed();
    }

    // Decides if an vegetable is ready to be spawned
    private bool EnemyReadyToSpawn(float currentTime) {
        if (currentTime >= spawnSpeed) {
            return true;
        } else {
            return false;
        }
    }

    // Spawns a random vegetable
    private void spawnVegetable() {
        // Get the random vegetable
        Round.EnemyAmount[] spawnOptions = roundManager.GetCurrentRound().enemies;
        int randomIndex = Random.Range(0, spawnOptions.Length);
        GameObject enemy = spawnOptions[randomIndex].enemy;
        
        // Decrement Amount of enemies left to spawn
        roundManager.GetCurrentRound().enemies[randomIndex].amount--;

        // Check here is all enemies have been spawned for the current round
        if (checkEnemiesAllSpawned()) {
            enemiesAllSpawned = true;
        }
        
        // Get Spawn Location
        Transform[] spawnLocations = roundManager.GetCurrentRound().spawnLocations;
        Transform spawnLocation = spawnLocations[Random.Range(0,spawnLocations.Length)];

        // Spawn the enemy
        GameObject spawnedEnemy = Instantiate(enemy, spawnLocation);
        spawnedEnemy.SetActive(true);
        
        // Add enemy to list of enemies currently in game
        vegetableList.Add(spawnedEnemy);
    }

    // Gets a spawn speed using the Vector 2 spawn speed variable in the Round Object
    private void getSpawnSpeed() {
        Vector2 spawnSpeedRange = roundManager.GetCurrentRound().spawnSpeed;
        spawnSpeed = Random.Range(spawnSpeedRange.x, spawnSpeedRange.y);
    }

    // Check if all enemies have been spawned for a certain round
    private bool checkEnemiesAllSpawned() {
        Round.EnemyAmount[] spawnOptions = roundManager.GetCurrentRound().enemies;
        foreach (Round.EnemyAmount enemy in spawnOptions) {
            if (enemy.amount > 0) {
                return false;
            }
        }
        return true;
    }

}
