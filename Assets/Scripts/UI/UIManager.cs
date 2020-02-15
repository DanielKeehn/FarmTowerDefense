using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject spawnPointsAmount;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().attackModeEvent += updateStateUI;
        FindObjectOfType<GameManager>().spawnModeEvent += updateStateUI;
        FindObjectOfType<GameManager>().upgradeModeEvent += updateStateUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSpawnPointsAmountUI(int newNum){
        string newNumString = newNum.ToString();
        spawnPointsAmount.GetComponent<TMPro.TextMeshProUGUI>().text = newNumString;
    }

    // This function changes the UI on screen when a user changes states
    public void updateStateUI() {
        Transform canvas = transform.GetChild(0);
        int UIModes = canvas.childCount;
        int currState = FindObjectOfType<GameManager>().getCurrentState();
         for (int i = 0; i < UIModes; i++) {
            GameObject currUIMode = canvas.GetChild(i).gameObject;
            if (currState == 3) {
                if (currUIMode.tag == "AttackMode") {
                    currUIMode.SetActive(true);
                } else {
                    currUIMode.SetActive(false);
                }
            }             
            if (currState == 4) {
                if (currUIMode.tag == "SpawnMode") {
                    currUIMode.SetActive(true);
                } else {
                    currUIMode.SetActive(false);
                }
            }
            if (currState == 5) {
                if (currUIMode.tag == "UpgradeMode") {
                    currUIMode.SetActive(true);
                } else {    
                    currUIMode.SetActive(false);
                }
            }
        }
    }
}
