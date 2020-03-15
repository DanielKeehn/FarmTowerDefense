using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;

public class PathFinder : MonoBehaviour {

	// ArrayList of all possible targets
	ArrayList targetAL = new ArrayList();
	
	// This is the current target
	public GameObject target;

	// This is a reference to the farmhouse
	public GameObject farmhouse;
	
	public NavMeshAgent agent;

	void Start() {
		// The farmhouse is added to the list of targets if the object is an enemy and it is the default target
		if (gameObject.tag == "Enemy") {
			targetAL.Add(farmhouse);
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
		foreach (GameObject target in targetAL) {
			Debug.Log(target);
		}
	}

	// This method adds targets to the target array list
	public void addTarget(GameObject newTarget) {
		targetAL.Add(newTarget);
	}
}