using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Potato : Enemy
{
    public Potato()
    {
        name = "Potato";
        spell = 17;
        health = 17;
        isUnlocked = true;
    }
}