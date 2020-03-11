using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class Carrot : Enemy
{
    public Carrot()
    {
        name = "Carrot";
        spell = 8;
        costToKill = 8;
        isUnlocked = true;
    }
}