using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class AppleTree : Enemy
{
    public AppleTree()
    {
        name = "Apple Tree";
        spell = 15;
        costToKill = 15;
        isUnlocked = true;
    }
}