using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls all the actions on screen that happen with the animals the player spawns on screen

public class AnimalManager : MonoBehaviour
{
    public Dictionary<string, GameObject> animalDict;

    // Start is called before the first frame update
    void Start()
    {
        //This adds every animal which are children of the animal manager to a dictionary so ana animals attributes can be edited
        animalDict = new Dictionary<string, GameObject>();
        foreach (Transform child in transform) {
            string name = child.gameObject.name;
            animalDict.Add(name,child.gameObject);

			Animal animal = child.gameObject.GetComponent<Animal>();
			if (animal.isUnlocked)
			{
				UnlockAnimal(animal.name);
			}
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This runs when a player unlocks an animal, the spawn manager will take note of this when this method runs as well
    public void UnlockAnimal(string name) {
        GameObject foundAnimal = animalDict[name];
        Animal animalScript = foundAnimal.gameObject.GetComponent<Animal>();
        animalScript.isUnlocked = true;
        SpawnManager sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        sm.addAnimalToUnlockedDict(foundAnimal);
    }
}
