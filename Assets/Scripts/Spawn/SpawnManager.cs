using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    // The current tile the spawn manager is looking at
    private Tile currentTile; 

    // The current preview for a spawned animal
    private GameObject currentPreview;

    public TextMeshProUGUI spawnPointsUI;

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
        try {
            SwitchBetweenAttackAndSpawnMode gameManager = GameObject.FindWithTag("GameManager").GetComponent<SwitchBetweenAttackAndSpawnMode>();
            gameManager.runSpawnMode += CheckForSpawnAnimal;
            gameManager.switchFromSpawnToAttack += DeactivateSpawnManager;
            gameManager.switchFromAttackToSpawn += ActivateSpawnManager;
        } catch {
            throw new System.ArgumentException("Couldn't Add CheckForSpawnAnimal() Function To runSpawnMode Event");
        }
        
        playerSelectedAnimal = UnlockedAnimals[0];
        spawnPointsUI.text = spawnPoints.ToString();
        DeactivateSpawnManager();
    }

    // This checks if a player is pressing the spawn button when a player is in spawn mode and creates a raycast
    void CheckForSpawnAnimal() {
        RaycastHit hitInfo;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hitInfo)) {
            GameObject hitTile = hitInfo.transform.gameObject;
            Debug.Log(hitTile.tag);
            if (hitTile.tag == "SpawnTile") {
                if (currentTile != null) {
                    currentTile.ChangeTileColorToDefault();
                }
                currentTile = hitTile.transform.parent.gameObject.GetComponent<Tile>();
                currentTile.ChangeTileColorToSpawnColor();
                PlaceAnimalPreviewOnGrid();
                if (currentTile.CanSpawn()) {
                    if (Input.GetButtonDown("Fire1")) {
                        SpawnAnimal(playerSelectedAnimal, hitInfo.point);
                    }
                }
            }
        }
    }

    public void PlaceAnimalPreviewOnGrid() {
        if (currentPreview != null) {
            Destroy(currentPreview);
            currentPreview = null;
        }
        GameObject getAnimalPreview = playerSelectedAnimal.GetComponent<Animal>().preview;
        Quaternion worldRotation = transform.rotation;
        Vector3 spawnPosition = currentTile.transform.position; 
        currentPreview = Instantiate(getAnimalPreview, spawnPosition, worldRotation);
        currentPreview.transform.parent = gameObject.transform;
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
			
            Vector3 spawnPosition = currentTile.transform.position;
			
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
            spawnPointsUI.text = spawnPoints.ToString();

        
        } else {
            Debug.Log("You don't have enough spawn points to spawn a " + animalScript.name);
        }
    }

    // Hides spawnmanager which also hides grid and animal preview
    // Runs when spawn mode is exited
    public void ActivateSpawnManager() {
        gameObject.SetActive(true);
    }

    public void DeactivateSpawnManager() {
        gameObject.SetActive(false);
    }
}
