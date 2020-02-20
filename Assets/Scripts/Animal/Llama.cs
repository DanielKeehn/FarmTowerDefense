using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Animal

public class Llama : Animal
{
    public Llama()
    {
        name = "Llama";
        health = 5;
        costToSpawn = 5;
        isUnlocked = true;
    }
}