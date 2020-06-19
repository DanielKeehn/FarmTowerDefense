using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    // The color of a tile when not being looked at
    private Color defaultColor;
    // The color of a tile when the player can spawn from this tile
    public Color canSpawnColor;
    // The color of the tile when the player cannot spawn from this tile
    public Color cannotSpawnColor;

    private MeshRenderer myRend;
    
    // Determines if a tile can be spawned on
    public bool canSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        canSpawn = true;
        myRend = GetComponent<MeshRenderer>();
        defaultColor = myRend.material.color;
    }

    // Change Color to Default Color
    public void ChangeTileColorToDefault() {
        myRend.material.color = defaultColor;
    }

    // Change color to Can Spawn or Cannot Spawn Color
    public void ChangeTileColorToSpawnColor() {
        if (canSpawn) {
            myRend.material.color = canSpawnColor;
        } else {
            myRend.material.color = cannotSpawnColor;
        }
    }

    public bool CanSpawn() {
        if (canSpawn) {
            return true;
        } else {
            return false;
        }
    }
}
