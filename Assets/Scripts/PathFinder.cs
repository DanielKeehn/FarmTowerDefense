using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class PathFinder : MonoBehaviour {
	
	// This is the current target
	public GameObject target;

	// This is a reference to the farmhouse
	public GameObject farmhouse;
	
	public NavMeshAgent agent;

	public SpawnManager spawnManager;

	// This value will be true if this pathfinding is for an enemy and the enemy is targeting the farmhouse
	bool attackingFarmHouse;

	// This value keeps track of the index in the Array List of the gameobject the AI is attacking.
	// If the AI is an enemy, the index will be -1 if the AI is attacking the barn or a positive integer or zero if the enemy
	// is attacking an animal
	int enemyAttackingIndex;

	void Start() {
		// The farmhouse is added to the list of targets if the object is an enemy and it is the default target
		if (gameObject.tag == "Enemy") {
			target = farmhouse;
			attackingFarmHouse = true;
			agent.SetDestination(target.transform.position);
			enemyAttackingIndex = -1;
		} else {
			attackingFarmHouse = false;
			enemyAttackingIndex = 0;
		}
	}

	void Update()
	{
		updateTarget();
	}

	void OnTriggerEnter(Collider other) {
		if(other.transform.gameObject == target) {
			Debug.Log("arrived at destination!");
			if (gameObject.tag == "Enemy") {
				gameObject.GetComponent<Enemy>().BeginAttack(target, enemyAttackingIndex);
			}
		}
	}

	// This takes in all the possible targets and picks the closest target
	void updateTarget() {
		
		// These variables represent the closest target and the distanc of this closest object
		GameObject closestTarget = null;
		float closestTargetDistance = float.PositiveInfinity;
		float distance;
		
		if (gameObject.tag == "Enemy") {
			distance = Vector3.Distance(farmhouse.transform.position, transform.position);
			if (distance < closestTargetDistance) {
				closestTargetDistance = distance;
				closestTarget = farmhouse;
				attackingFarmHouse = true;
				enemyAttackingIndex = -1;	
			}
			ArrayList spawnedAnimals = spawnManager.getSpawnedAnimalsArray();
			int currIndex = 0;
			foreach (GameObject animal in spawnedAnimals) {
				distance = Vector3.Distance(animal.transform.position, transform.position);
				if (distance < closestTargetDistance) {
					closestTargetDistance = distance;
					closestTarget = animal;
					attackingFarmHouse = false;
					enemyAttackingIndex = currIndex;
				}
				currIndex++;
			}
		}
		
		target = closestTarget;
		agent.SetDestination(target.transform.position);
		
	}	
}