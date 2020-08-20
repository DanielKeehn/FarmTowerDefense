using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Apple : Enemy
{
    public Apple()
    {
        name = "Apple";
        spell = 15;
        health = 15;
        isUnlocked = true;
    }
}