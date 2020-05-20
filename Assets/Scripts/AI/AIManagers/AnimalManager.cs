using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script keeps track of all the attributes of animals such as if an animal is unlocked
// Put an animal under the animal manager object and the animal manager can change it's values

public class AnimalManager : AIManager
{
    // A list of unlocked animals
    public List<GameObject> UnlockedAnimals;

    // Creates list of animals and seperate list of unlocked animals
    private void Start() {
        base.CreatePrefabList();
        CreateUnlockedAnimalsList();
    }
    
    // Creates a list of unlocked animals at the beginning of a game
    protected void CreateUnlockedAnimalsList() {
        foreach (GameObject animal in base.AIPrefabs) {
            try {
                Animal animalScript = animal.GetComponent<Animal>();
                if (animalScript.isUnlocked) {
                    UnlockedAnimals.Add(animal);
                }
            } catch {
                throw new System.ArgumentException("Couldn't find the Animal script in the animal prefab");
            }
        }
    }
    
    // This runs when a player unlocks an animal
    public void UnlockAnimal(string name) {
        // GameObject foundAnimal = animalDict[name];
        // Animal animalScript = foundAnimal.gameObject.GetComponent<Animal>();
        // animalScript.isUnlocked = true;
        // SpawnManager sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        // sm.addAnimalToUnlockedDict(foundAnimal);
    }
}
