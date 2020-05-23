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
    private void Awake() {
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
    public void UnlockAnimal(GameObject animal) {
        // Make sure parameter is contained in the list of animal prefabs
        if (base.AIPrefabs.Contains(animal)) {
            Animal animalScript = animal.GetComponent<Animal>(); 
            // Make sure animal is not already unlocked
            if (!animalScript.isUnlocked) {
                // Unlock and add animal to unlocked animals dict here
                animalScript.isUnlocked = true;
                UnlockedAnimals.Add(animal);
            } else {
                throw new System.ArgumentException("Couldn't unlock " + animal + " because animal appears to already be unlocked");
            }
        } else {
            throw new System.ArgumentException("Unable to find " + animal + " prefab. Make sure this gameObject is in the list of prefabs under the animal manager");
        }
    }
}
