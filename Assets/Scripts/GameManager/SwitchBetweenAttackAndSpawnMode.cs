using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class creates 4 events related to the spawn mode and attack mode
Event 1 - runAttackMode: This event runs every frame that the player is on attack mode
Event 2 - runSpawnMode: This event runs every frame that the player is on spawn mode
Event 3 - switchFromAttacktoSpawn: This event runs once when the player switches from attack mode to spawn mode
Event 4 - switchFromSpawntoAttack: This event runs once when the player switches from spawn mode to attack mode
*/
public class SwitchBetweenAttackAndSpawnMode : MonoBehaviour
{
    public delegate void RunAttackModeDelegate();
    public event RunAttackModeDelegate runAttackMode;   

    public delegate void RunSpawnModeDelegate();
    public event RunSpawnModeDelegate runSpawnMode;

    public delegate void SwitchFromAttackToSpawnDelegate();
    public event SwitchFromAttackToSpawnDelegate switchFromAttackToSpawn;

    public delegate void SwitchFromSpawnToAttackDelegate();
    public event SwitchFromSpawnToAttackDelegate switchFromSpawnToAttack;

    // Determines if on Attack Mode or Spawn Mode
    // True = Attack Mode
    // False = Spawn Mode
    public bool onAttackMode;     
    // Game Starts on Attack Mode When First Run
    void Start()
    {
        onAttackMode = true;
    }

    // Runs Attack Mode or Spawn Mode event every frame and changes modes if neccesary 
    void Update()
    {
        if (onAttackMode) {
            if (runAttackMode != null) { 
            runAttackMode();
            }
        } else {
            if (runSpawnMode != null) { 
                runSpawnMode();
            }
        }
        if (Input.GetButtonDown("SpawnMode")) {
            if (onAttackMode) {
                if (switchFromAttackToSpawn != null) {
                    switchFromAttackToSpawn();    
                }
                Debug.Log("Switching From Attack Mode to Spawn Mode");
                onAttackMode = false;
            } else {
                if (switchFromSpawnToAttack != null) {
                    switchFromSpawnToAttack();
                }
                Debug.Log("Swithing From Spawn Mode to Attack Mode");
                onAttackMode = true;
            }
        }
    }
}
