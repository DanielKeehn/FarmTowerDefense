using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls all the actions on screen that happen with the animals the player spawns on screen

public class EnemyManager : MonoBehaviour
{

    public Dictionary<string, GameObject> enemyDict;

    // Start is called before the first frame update
    void Start()
    {
        //This adds every animal which are children of the animal manager to a dictionary so ana animals attributes can be edited
        enemyDict = new Dictionary<string, GameObject>();
        foreach (Transform child in transform)
        {
            string name = child.gameObject.GetComponent<Enemy>().name;
            enemyDict.Add(name, child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    // This runs when a player unlocks an animal, the spawn manager will take note of this when this method runs as well
    public void UnlockEnemy(string name)
    {
        GameObject foundEnemy = enemyDict[name];
        Enemy enemyScript = foundEnemy.gameObject.GetComponent<Enemy>();
        enemyScript.isUnlocked = true;

    }
}
