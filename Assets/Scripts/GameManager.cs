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

    public delegate void SpawnModeDelegate();
    public event SpawnModeDelegate spawnModeEvent;   

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
            if (Input.GetButtonDown("SpawnMode")) {
                goToSpawnMode();
                currState = ((int)gameState.SPAWNMODE); 
            }
        } else if (currState == ((int)gameState.SPAWNMODE)) {
            if (Input.GetButtonDown("SpawnMode")) {
                goToAttackMode();
                currState = ((int)gameState.ATTACKMODE); 
            } 
        } else if (currState == ((int)gameState.UPGRADEMENU)) {
 
        } 
    }

    void goToAttackMode() {
        if (attackModeEvent != null) { 
            attackModeEvent();
        }
    }

    void goToSpawnMode() {
        if (spawnModeEvent != null) { 
            spawnModeEvent();
        }
    }

}
