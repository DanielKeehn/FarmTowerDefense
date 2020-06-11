using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{

    // Creates the initial grid where animals can be spawned

    // An object representing a single tile
    public GameObject tile;
    public float tileSize;
    
    // Dimensions of grid
    public int gridLength;
    public int gridHeight;

    // Reference to SpawnManager
    private GameObject spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindWithTag("SpawnManager");
        gameObject.transform.parent = spawnManager.transform;
        createGrid();
    }

    public void createGrid() {
        float currentPosX = 0;
        float currentPosZ = 0;
        for (int x  = 0; x < gridLength; x++) {
            currentPosX += tileSize;
            currentPosZ = 0;
            for (int z = 0; z < gridHeight; z++) {
                Vector3 position = new Vector3(currentPosX + 0.5f, 0, currentPosZ + 0.5f);
                GameObject currentTile = Instantiate(tile, position, Quaternion.identity);
                currentTile.transform.localScale = new Vector3(tileSize, .01f ,tileSize);
                currentTile.transform.SetParent(transform);
                currentTile.SetActive(true);
                currentPosZ += tileSize;
            }
        }
    }
}
