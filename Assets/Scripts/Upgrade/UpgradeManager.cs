using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public Dictionary<string, GameObject> animalDict;
    // This is the current animal being displayed on the upgrade menu
    public string currentAnimal;

    private IEnumerator coroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        // This gets the unlcoked animals dict from the spawn manager
         animalDict = FindObjectOfType<SpawnManager>().GetComponent<SpawnManager>().getAnimalDict();

        // This coroutine is neccesary because the changeCurrentAnimal method cannot run until the spawn manager start method and
        // animal manager run so the unlockedAnimal Dict can be initialized
        coroutine = Wait(0.01f);
        StartCoroutine(coroutine);   
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        changeCurrentAnimal("Cow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This changes what the current animal is
    void changeCurrentAnimal(string animal) {
        currentAnimal = animal;
        updateUpgradeMenuUI();
    }

    void updateUpgradeMenuUI() {
        FindObjectOfType<UIManager>().GetComponent<UIManager>().changeUpgradeStatsUI();
    }

    public GameObject getCurrentAnimal() {
        return animalDict[currentAnimal];
    }

}
