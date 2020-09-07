using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnip : Enemy
{
       public Turnip()
    {
        name = "Turnip";
        spell = 15;
        health = 15;
        isUnlocked = true;
    }
}