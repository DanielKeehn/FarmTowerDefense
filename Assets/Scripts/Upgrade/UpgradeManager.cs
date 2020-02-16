using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public Dictionary<string, GameObject> animalDict;
    // This is the current animal being displayed on the upgrade menu
    public string currentAnimal;

    // Start is called before the first frame update
    void Start()
    {
        // This gets the unlcoked animals dict from the spawn manager
         animalDict = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>().getAnimalDict();
         currentAnimal = "Cow";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This changes what the current animal is
    void changeCurrentAnimal(string animal) {
        currentAnimal = animal;
    }

    public string getCurrentAnimal() {
        return currentAnimal;
    }

}
