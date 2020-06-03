using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTileSelected : MonoBehaviour
{

    // The color of a tile when not being looked at
    private Color defaultColor;
    // The color of a tile when the player can spawn from this tile
    public Color canSpawnColor;
    // The color of the tile when the player cannot spawn from this tile
    public Color cannotSpawnColor;

    private MeshRenderer myRend;
    private bool isSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        defaultColor = myRend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
