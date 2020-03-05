using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Corn : Enemy
{
    public Corn()
    {
        name = "Corn";
        spell = 5;
        costToKill = 5;
        isUnlocked = true;
    }
}