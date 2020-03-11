using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Watermelon : Enemy
{
    public Watermelon()
    {
        name = "Watermelon";
        spell = 20;
        health = 20;
        isUnlocked = true;
    }
}