using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Sugarcane : Enemy
{
    public Sugarcane()
    {
        name = "Sugarcane";
        spell = 15;
        costToKill = 15;
        isUnlocked = true;
    }
}