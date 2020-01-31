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
        } else if (currState == ((int)gameState.SPAWNMODE)) {
            updateSpawnMode();
            if (Input.GetButtonDown("SpawnMode")) {
                currState = ((int)gameState.ATTACKMODE); 
                goToAttackMode();
            } 
        } else if (currState == ((int)gameState.UPGRADEMENU)) {
 
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

    public int getCurrentState() {
        return currState;
    }

}
