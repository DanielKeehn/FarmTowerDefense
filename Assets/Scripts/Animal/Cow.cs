using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Cow : Animal
{
    public Cow() {
        name = "Cow";
        health = 10;
        costToSpawn = 10;
        isUnlocked = true;
    }
}
