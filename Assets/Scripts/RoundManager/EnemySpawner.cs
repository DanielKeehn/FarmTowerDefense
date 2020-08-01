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

    // The current enemies possible to spawn
    private Round.EnemyAmount[] spawnOptions;
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
        spawnOptions = roundManager.GetCurrentRound().enemies;
        getSpawnSpeed();
    }

    void Update()
    {
        if (!enemiesAllSpawned) {
            spawnTimer += Time.deltaTime;
            if (EnemyReadyToSpawn(spawnTimer)) {
                if (checkEnemiesAllSpawned()) {
                    enemiesAllSpawned = true;
                } else {
                    getSpawnSpeed();
                    spawnTimer = 0.0f;
                    spawnVegetable();
                    
                }
            }
        }
    }

    // Run this function when a new round starts to reset values for spawning logic
    public void ResetEnemySpanwer() {
        spawnTimer = 0.0f;
        enemiesAllSpawned = false;
        spawnOptions = roundManager.GetCurrentRound().enemies;
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

    // Spawns a random enemy
    private void spawnVegetable() {
        // Boolean determing if enemy is found that can be spawned
        bool foundEnemy = false;
        // The enemy you want to spawn
        GameObject enemy;
        
        // The index of the enemy you want to spawn
        int randomIndex = 0;

        // Run while loop until enemy is found
        while (!foundEnemy) {
            // Get the random enemy index
            randomIndex = Random.Range(0, spawnOptions.Length);
            
            // Check if there the amount for this enemy is greater than zero
            if (spawnOptions[randomIndex].amount > 0) {
                foundEnemy = true;
                // Assign enemy variable
                enemy = spawnOptions[randomIndex].enemy;
            // Remove index with zero enemies here if enemy can't be spawned 
            } else {
                var enemies = new List<Round.EnemyAmount>(spawnOptions);
                enemies.RemoveAt(randomIndex);
                spawnOptions = enemies.ToArray();
            }
        }

        // Spawn the enemy here
        
        // Decrement enemy amount first
        spawnOptions[randomIndex].amount--;
        
        // Get Spawn Locations
        Transform[] spawnLocations = spawnOptions[randomIndex].spawnLocations;
        Transform spawnLocation = spawnLocations[Random.Range(0,spawnLocations.Length)];

        // Spawn the enemy
        GameObject spawnedEnemy = Instantiate(spawnOptions[randomIndex].enemy, spawnLocation);
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
        foreach (Round.EnemyAmount enemy in spawnOptions) {
            if (enemy.amount > 0) {
                return false;
            }
        }
        return true;
    }
}
