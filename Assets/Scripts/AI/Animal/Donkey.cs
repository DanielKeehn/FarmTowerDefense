using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Donkey : Animal
{
    public Donkey()
    {
        name = "Donkey";
        health = 8;
        costToSpawn = 8;
        isUnlocked = true;
    }
}
