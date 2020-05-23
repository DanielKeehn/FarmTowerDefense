using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    // This is the currency that determines if an animal can be spawned or not
    public int spawnPoints;

    // A list of unlocked animals collected from animal manager
    public List<GameObject> UnlockedAnimals;
	
    // The animal the player is currently viewing when in spawn mode
    [HideInInspector] public GameObject playerSelectedAnimal;

    // The grid where a player can spawn animals
	private Grid grid;

	private void Awake()
	{
		grid = FindObjectOfType<Grid>();
	}

	// Start is called before the first frame update
	void Start()
    {
        try {
            GameObject animalManager = GameObject.FindWithTag("AnimalManager");
            UnlockedAnimals = animalManager.GetComponent<AnimalManager>().UnlockedAnimals;
        } catch {
            throw new System.ArgumentException("Could not create list of unlocked animals, make sure you have an animal manager with an animal manager tag");
        }
        FindObjectOfType<GameManager>().runSpawnMode += CheckForSpawnAnimal;
        playerSelectedAnimal = UnlockedAnimals[0];
        //FindObjectOfType<UIManager>().GetComponent<UIManager>().changeSpawnPointsAmountUI(spawnPoints);
    }

    // This checks if a player is pressing the spawn button when a player is in spawn mode and creates a raycast
    void CheckForSpawnAnimal() {
        if (Input.GetButtonDown("Fire1")) {
			RaycastHit hitInfo;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hitInfo))
			{
				SpawnAnimal(playerSelectedAnimal, hitInfo.point);
			}
        }
    }

    // This spawns an animal onto the screen
    void SpawnAnimal(GameObject animal, Vector3 nearPoint) {
        // The script of the animal object
        Animal animalScript = animal.GetComponent<Animal>();
        // The cost to spawn an animal
        int costToSpawn = animalScript.costToSpawn;

        
        // First check if the player has enough spawn points to spawn an animal
        if (costToSpawn <= spawnPoints) {         
            
            // Create a rotation and position for an animal to spawn
            Quaternion worldRotation = transform.rotation;
			Vector3 spawnPosition = grid.GetNearestPointOnGrid(nearPoint);
			
            // Check if there is something currently on a tile
            if (spawnPosition != Vector3.zero) {
                // Here is where animal is spawned
				GameObject currAnimal = Instantiate(animal, spawnPosition, worldRotation);
				currAnimal.SetActive(true);
				spawnPoints -= costToSpawn;

                // Add this instance to a list of currently spawned animals
                try {
                    List<GameObject> animalList = GameObject.FindWithTag("GameManager").GetComponent<CurrentAttackableObjects>().animalList;
                    animalList.Add(currAnimal);
                } catch {
                    throw new System.ArgumentException("Couldn't find list of currently spawned animals, make sure you have a gamemanager with a gamemanager tag that has a current attacktable objects script attached");
                }
				//FindObjectOfType<UIManager>().GetComponent<UIManager>().changeSpawnPointsAmountUI(spawnPoints);
			
            } else {
				Debug.Log("There is something on this tile already");
			}
        
        } else {
            Debug.Log("You don't have enough spawn points to spawn a " + animalScript.name);
        }
    }
}
