using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCollision : MonoBehaviour
{

    // Reference to the tile object
    private Tile tile;

    // Keeps track of all objects colliding with this tile collider
    private int objectsColliding;

    private void Awake() {
        tile =  transform.parent.gameObject.GetComponent<Tile>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Walkable" && other.gameObject.tag != "Ground" && other.gameObject.tag != "SpawnTile") {
            objectsColliding++;
            tile.canSpawn = false;
        } 
    }
    private void OnTriggerExit(Collider other) {
        objectsColliding--;
        if (objectsColliding <= 0) {
            tile.canSpawn = true;
        }
    }
}
