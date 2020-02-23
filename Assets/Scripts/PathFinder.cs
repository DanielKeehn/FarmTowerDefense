using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour {
	public GameObject target;
	public NavMeshAgent agent;

	void Start() {
		agent.SetDestination(target.transform.position);
	}

	void OnTriggerEnter(Collider other) {
		if(other.transform.gameObject == target) {
			print("arrived at destination!");
		}
	}
}