using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Sunflower : Enemy
{
    public Sunflower()
    {
        name = "Sunflower";
        spell = 18;
        health = 18;
        isUnlocked = true;
    }
}