using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Notice this class is a child of Enemy

public class VenusFlytrap : Enemy
{
    public VenusFlytrap()
    {
        name = "Venus Flytrap";
        spell = 25;
        costToKill = 25;
        isUnlocked = true;
    }
}