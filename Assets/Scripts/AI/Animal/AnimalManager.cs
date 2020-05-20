using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script keeps track of all the attributes of animals such as if an animal is unlocked
// Put an animal under the animal manager object and the animal manager can change it's values

public class AnimalManager : AIManager
{
    // This runs when a player unlocks an animal, the spawn manager will take note of this when this method runs as well
    public void UnlockAnimal(string name) {
        // GameObject foundAnimal = animalDict[name];
        // Animal animalScript = foundAnimal.gameObject.GetComponent<Animal>();
        // animalScript.isUnlocked = true;
        // SpawnManager sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        // sm.addAnimalToUnlockedDict(foundAnimal);
    }
}
