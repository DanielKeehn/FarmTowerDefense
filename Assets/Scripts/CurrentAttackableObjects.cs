using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class keeps track of all of the current objects able to be attacked in game for both the vegetables and animals
// Attach this to the game manager object

public class CurrentAttackableObjects : MonoBehaviour
{
    // A list of animals currently spawned in game
    // This also includes the player and farmhouse because the vegetables can also attack the player or farmhouse
    public List<GameObject> animalList;

    // A list of all vegetables spawned in game
    public List<GameObject> vegetableList;


}
