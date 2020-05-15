using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Pig : Animal
{
    public Pig()
    {
        name = "Pig";
        health = 4;
        costToSpawn = 4;
        isUnlocked = true;
    }
}
