using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this class to an enemy or animal manager
// Put all animals or enemies under this manager 

public abstract class AIManager : MonoBehaviour
{

    // A list of all AI prefabs
    public List<GameObject> AIPrefabs;
    
    void Start()
    {
        CreatePrefabList();
    }

    // Creates a list of AI prefabs that are under the manager
    protected void CreatePrefabList() {
        foreach (Transform child in transform) {
            AIPrefabs.Add(child.gameObject);
        }
    }
}
