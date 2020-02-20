using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Goose : Animal
{
    public Goose()
    {
        name = "Goose";
        health = 20;
        costToSpawn = 20;
        isUnlocked = true;
    }
}
