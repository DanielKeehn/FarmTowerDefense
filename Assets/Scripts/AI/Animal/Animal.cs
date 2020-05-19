using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class for animals

public abstract class Animal: AI
{
    // These are the varaibles all animals have that other AI do not
    // How much it costs to spawn an animal 
    public int costToSpawn;
    // If an animal is unlocked
    public bool isUnlocked;
    // If an animal is attacking
}
