using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Goat : Animal
{
    public Goat()
    {
        name = "Goat";
        health = 3;
        costToSpawn = 3;
        isUnlocked = true;
    }
}
