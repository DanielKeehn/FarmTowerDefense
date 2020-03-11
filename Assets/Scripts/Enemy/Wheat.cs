using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Wheat : Enemy
{
    public Wheat()
    {
        name = "Wheat";
        spell = 13;
        health = 13;
        isUnlocked = true;
    }
}