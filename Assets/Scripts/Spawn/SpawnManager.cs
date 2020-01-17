using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // This is the currency that determines if an animal can be spawned or not
    public int spawnPoints;

    Dictionary<string, GameObject> unlockedAnimalsDict;
    int unlockedAnimalDictSize;

    // The player transform that will be used to determine the position of a spawn
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        // The initial amount of spawn points a player has
        spawnPoints = 100;
        unlockedAnimalDictSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // returns a boolean value and determines if a animal can be spawned or not
    bool isSpawnable(int cost) {
        return (cost <= spawnPoints);
    }
}
