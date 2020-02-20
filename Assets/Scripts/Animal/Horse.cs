using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Horse : Animal
{
    public Horse()
    {
        name = "Horse";
        health = 7;
        costToSpawn = 7;
        isUnlocked = true;
    }
}