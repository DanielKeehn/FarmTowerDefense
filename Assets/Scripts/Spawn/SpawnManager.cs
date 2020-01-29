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

    // returns a boolean value and determines if a animal can be spawned or not based on the amount of spawn points a player has
    bool isSpawnable(int cost) {
        return (cost <= spawnPoints);
    }

    // This method runs after an animal is unlocked in the animal manager and allows an animal to be spawned
    public void addAnimalToUnlockedDict(GameObject unlockedAnimal) {
        unlockedAnimalDictSize++;
        string name = unlockedAnimal.gameObject.name;
        unlockedAnimalsDict.Add(name,unlockedAnimal);
    }

    //    // This checks is an animal can be spawned
    // void CheckForSpawnAnimal() {
    //     if (Input.GetButtonDown("Fire1")) {
    //         SpawnAnimal("Cow");
    //     }
    // }

    // // This spawns an animal onto the screen
    // void SpawnAnimal(string name) { 
    //     GameObject foundAnimal = animalDict[name];
    //     playerPos = playerTransform.position;
    //     playerDirection = playerTransform.forward;
    //     playerRotation = playerTransform.rotation;
    //     spawnDistance = 10;
    //     spawnPosition = playerPos + playerDirection*spawnDistance;
    //     GameObject currAnimal = Instantiate(foundAnimal, spawnPosition, playerRotation);
    //     currAnimal.SetActive(true);
    //     UnlockAnimal("Cow");
    // }
}
