using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    // public GameObject spawnPointsAmount;

    // // This is all of the UI that will be altered when in the upgrade menu
    // public GameObject currentAnimalUI;
    // public GameObject currentHealthUI;
    // public GameObject currentCostToSpawnUI;

    // public GameObject roundNumberUI;
    // public GameObject enemiesLeftUI;


    // // Start is called before the first frame update
    // void Start()
    // {
    //     FindObjectOfType<GameManager>().attackModeEvent += updateStateUI;
    //     FindObjectOfType<GameManager>().spawnModeEvent += updateStateUI;
    //     FindObjectOfType<GameManager>().upgradeModeEvent += updateStateUI;
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // public void changeSpawnPointsAmountUI(int newNum){
    //     string newNumString = newNum.ToString();
    //     spawnPointsAmount.GetComponent<TMPro.TextMeshProUGUI>().text = newNumString;
    // }

    // // This function changes the UI on screen when a user changes states
    // public void updateStateUI() {
    //     Transform canvas = transform.GetChild(0);
    //     int UIModes = canvas.childCount;
    //     int currState = FindObjectOfType<GameManager>().getCurrentState();
    //      for (int i = 0; i < UIModes; i++) {
    //         GameObject currUIMode = canvas.GetChild(i).gameObject;
    //         if (currState == 3) {
    //             if (currUIMode.tag == "AttackMode") {
    //                 currUIMode.SetActive(true);
    //             } else {
    //                 currUIMode.SetActive(false);
    //             }
    //         }             
    //         if (currState == 4) {
    //             if (currUIMode.tag == "SpawnMode") {
    //                 currUIMode.SetActive(true);
    //             } else {
    //                 currUIMode.SetActive(false);
    //             }
    //         }
    //         if (currState == 5) {
    //             if (currUIMode.tag == "UpgradeMode") {
    //                 currUIMode.SetActive(true);
    //             } else {    
    //                 currUIMode.SetActive(false);
    //             }
    //         }
    //     }
    // }

    // // This function updates the UI for what is shown on the upgrade menu
    // public void changeUpgradeStatsUI() {
    //     GameObject currentAnimal = FindObjectOfType<UpgradeManager>().GetComponent<UpgradeManager>().getCurrentAnimal();
    //     string name = currentAnimal.GetComponent<Animal>().name;
    //     string health = currentAnimal.GetComponent<Animal>().health.ToString();
    //     string costToSpawn = currentAnimal.GetComponent<Animal>().costToSpawn.ToString();
    //     currentAnimalUI.GetComponent<TMPro.TextMeshProUGUI>().text = name;
    //     currentHealthUI.GetComponent<TMPro.TextMeshProUGUI>().text = health;
    //     currentCostToSpawnUI.GetComponent<TMPro.TextMeshProUGUI>().text = costToSpawn;
    // }

    // public void updateRound(int roundNumber) {
    //     roundNumberUI.GetComponent<TMPro.TextMeshProUGUI>().text = roundNumber.ToString();
    // }

    // public void updateEnemiesLeft(int enemiesLeft) {
    //     enemiesLeftUI.GetComponent<TMPro.TextMeshProUGUI>().text = enemiesLeft.ToString();
    // }

}
