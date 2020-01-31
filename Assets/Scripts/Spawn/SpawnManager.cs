using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // This is the currency that determines if an animal can be spawned or not
    public int spawnPoints;

    public Dictionary<string, GameObject> unlockedAnimalsDict;
    int unlockedAnimalDictSize;

    // The player transform that will be used to determine the position of a spawn
    public Transform playerTransform;
    Vector3 playerPos;
    Vector3 playerDirection;
    Quaternion playerRotation;
    float spawnDistance;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        unlockedAnimalsDict = new Dictionary<string, GameObject>();
        // The initial amount of spawn points a player has
        unlockedAnimalDictSize = 0;

        FindObjectOfType<GameManager>().runSpawnMode += CheckForSpawnAnimal;

        FindObjectOfType<UIManager>().GetComponent<UIManager>().changeSpawnPointsAmountUI(spawnPoints);
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
        string name = unlockedAnimal.name;
        unlockedAnimalsDict.Add(name,unlockedAnimal);
    }

    // This checks is an animal can be spawned
    void CheckForSpawnAnimal() {
        //All the code in this method is temporary for now
        if (Input.GetButtonDown("Fire1")) {
            SpawnAnimal("Cow");
        }
    }

    // This spawns an animal onto the screen
    void SpawnAnimal(string name) { 
        GameObject foundAnimal = unlockedAnimalsDict[name];
        int costToSpawn = foundAnimal.GetComponent<Animal>().costToSpawn;
        if (isSpawnable(costToSpawn)) {
            playerPos = playerTransform.position;
            playerDirection = playerTransform.forward;
            playerRotation = playerTransform.rotation;
            spawnDistance = 10;
            spawnPosition = playerPos + playerDirection*spawnDistance;
            GameObject currAnimal = Instantiate(foundAnimal, spawnPosition, playerRotation);
            currAnimal.SetActive(true);
            spawnPoints -= costToSpawn;
            FindObjectOfType<UIManager>().GetComponent<UIManager>().changeSpawnPointsAmountUI(spawnPoints);
        } else {
            Debug.Log("You can't spawn a " + name);
        }
    }
}
