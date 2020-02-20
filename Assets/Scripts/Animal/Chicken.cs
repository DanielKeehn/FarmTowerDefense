using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Chicken : Animal
{
    public Chicken()
    {
        name = "Chicken";
        health = 2;
        costToSpawn = 2;
        isUnlocked = true;
    }
}