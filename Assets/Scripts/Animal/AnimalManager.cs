using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls all the actions on screen that happen with the animals the player spawns on screen

public class AnimalManager : MonoBehaviour
{

    public Dictionary<string, GameObject> animalDict;
    public Transform playerTransform;
    Vector3 playerPos;
    Vector3 playerDirection;
    Quaternion playerRotation;
    float spawnDistance;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        animalDict = new Dictionary<string, GameObject>();
        foreach (Transform child in transform) {
            string name = child.gameObject.name;
            animalDict.Add(name,child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSpawnAnimal();
    }


    // This checks is an animal can be spawned
    void CheckForSpawnAnimal() {
        if (Input.GetButtonDown("Fire1")) {
            SpawnAnimal("Cow");
        }
    }

    // This spawns an animal onto the screen
    void SpawnAnimal(string name) { 
        GameObject foundAnimal = animalDict[name];
        playerPos = playerTransform.position;
        playerDirection = playerTransform.forward;
        playerRotation = playerTransform.rotation;
        spawnDistance = 10;
        spawnPosition = playerPos + playerDirection*spawnDistance;
        GameObject currAnimal = Instantiate(foundAnimal, spawnPosition, playerRotation);
        currAnimal.SetActive(true);
    }
}
