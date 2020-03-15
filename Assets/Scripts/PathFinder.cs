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

	void Start() {
		// The farmhouse is added to the list of targets if the object is an enemy and it is the default target
		if (gameObject.tag == "Enemy") {
			target = farmhouse;
			agent.SetDestination(target.transform.position);
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
				gameObject.GetComponent<Enemy>().BeginAttack(target);
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
			}
			ArrayList spawnedAnimals = spawnManager.getSpawnedAnimalsArray();
			foreach (GameObject animal in spawnedAnimals) {
				distance = Vector3.Distance(animal.transform.position, transform.position);
				if (distance < closestTargetDistance) {
					closestTargetDistance = distance;
					closestTarget = animal;
				}
			}
		}
		
		target = closestTarget;
		agent.SetDestination(target.transform.position);
		
	}	
}