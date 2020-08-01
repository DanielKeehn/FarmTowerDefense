using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class for animals

[System.Serializable]

public abstract class Animal: AI
{
    [Header("Animal Variables")]
    // These are the varaibles all animals have that other AI do not
    // How much it costs to spawn an animal 
    public int costToSpawn;
    // If an animal is unlocked
    public bool isUnlocked;
    // The 2D Icon displaying in spawn mode for each animal
    public Sprite Icon;
    // The model of an animal that determines if an animal can be spawned or not
    public GameObject preview;
    
}
