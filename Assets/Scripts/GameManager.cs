using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int currState;

    enum gameState
    {
        TITLESCREEN = 0,
        PAUSESCREEN = 1,
        SETTINGS = 2,
        ATTACKMODE = 3,
        SPAWNMODE = 4,
        UPGRADEMENU = 5
    }

    public delegate void AttackModeDelegate();
    public event AttackModeDelegate attackModeEvent;

    public delegate void RunAttackModeDelegate();
    public event RunAttackModeDelegate runAttackMode;   

    public delegate void SpawnModeDelegate();
    public event SpawnModeDelegate spawnModeEvent;
    
    public delegate void RunSpawnModeDelegate();
    public event RunSpawnModeDelegate runSpawnMode; 

    public delegate void UpgradeModeDelegate();
    public event UpgradeModeDelegate upgradeModeEvent;
    
    public delegate void RunUpgradeModeDelegate();
    public event RunUpgradeModeDelegate runUpgradeMode;   

    // Start is called before the first frame update
    void Start()
    {
        currState = ((int)gameState.ATTACKMODE); 
    }

    // Update is called once per frame
    void Update()
    {
        if (currState == ((int)gameState.TITLESCREEN)) {

        } else if (currState == ((int)gameState.PAUSESCREEN)) {
 
        } else if (currState == ((int)gameState.SETTINGS)) {
 
        } else if (currState == ((int)gameState.ATTACKMODE)) {
            updateAttackMode();
            if (Input.GetButtonDown("SpawnMode")) {
                currState = ((int)gameState.SPAWNMODE); 
                goToSpawnMode();
            }
            if (Input.GetButtonDown("UpgradeMode")) {
                currState = ((int)gameState.UPGRADEMENU); 
                goToSpawnMode();
            }
        } else if (currState == ((int)gameState.SPAWNMODE)) {
            updateSpawnMode();
            if (Input.GetButtonDown("SpawnMode")) {
                currState = ((int)gameState.ATTACKMODE); 
                goToAttackMode();
            }
            if (Input.GetButtonDown("UpgradeMode")) {
                currState = ((int)gameState.UPGRADEMENU); 
                goToSpawnMode();
            } 
        } else if (currState == ((int)gameState.UPGRADEMENU)) {
            updateUpgradeMode();
            if (Input.GetButtonDown("UpgradeMode")) {
                currState = ((int)gameState.ATTACKMODE); 
                goToAttackMode();
            } 
        } 
    }

    void goToAttackMode() {
        if (attackModeEvent != null) { 
            attackModeEvent();
        }
    }

    void updateAttackMode() {
        if (runAttackMode != null) { 
            runAttackMode();
        }
    }

    void goToSpawnMode() {
        if (spawnModeEvent != null) { 
            spawnModeEvent();
        }
    }

    void updateSpawnMode() {
        if (runSpawnMode != null) { 
            runSpawnMode();
        }
    }

    
    void goToUpgradeMode() {
        if (spawnModeEvent != null) { 
            upgradeModeEvent();
        }
    }

    void updateUpgradeMode() {
        if (runUpgradeMode != null) { 
            runUpgradeMode();
        }
    }

    public int getCurrentState() {
        return currState;
    }

}
