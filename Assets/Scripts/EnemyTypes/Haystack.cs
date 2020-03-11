using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Haystack : Enemy
{
    public Haystack()
    {
        name = "Haystack";
        spell = 10;
        costToKill = 10;
        isUnlocked = true;
    }
}