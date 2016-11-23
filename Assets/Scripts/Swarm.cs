using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Swarm : MonoBehaviour
{

	List<GameObject> patchLocations;
	SwarmKeeper.SwarmStates state;
	SwarmKeeper.SwarmStates lastState;
	public NavMeshAgent agent;

	SwarmKeeper swarmkeeper;

	int level;
	int patchLimit;

	float pollenPayload;

	public int i;
	float cooldownTime;
	int cooldownStart;
	int cooldownEnd;

	GameObject hive;

	// Use this for initialization
	void Start () {
		//swarm = new SwarmClass ();
		patchLocations = new List<GameObject>();
		state = SwarmKeeper.SwarmStates.IDLE;
		agent = GetComponent<NavMeshAgent> ();

		hive = GameObject.FindGameObjectWithTag ("Hive");

		level = 1;
		patchLimit = 3;

		pollenPayload = 0;

		i = 0;
		cooldownTime = 5;

		swarmkeeper = GameObject.FindGameObjectWithTag ("SwarmKeeper").GetComponent<SwarmKeeper> ();
	}

	// Update is called once per frame
	void Update () {

		if (state == SwarmKeeper.SwarmStates.IDLE) {
			
		}

		if (state == SwarmKeeper.SwarmStates.BUILD) {

		}

		if (state == SwarmKeeper.SwarmStates.COLLECT) {

		}

		if (state == SwarmKeeper.SwarmStates.NURSE) {

		}

		if (state == SwarmKeeper.SwarmStates.COOLDOWN) {
			if ((int)Time.time == cooldownEnd) {
				//state = lastState;
			}
		}

		move ();

	}

	void appendHiveLocation() {
		patchLocations.Add (hive);
	}

	IEnumerator coolDown() {
		//state = SwarmKeeper.SwarmStates.COOLDOWN;
		agent.destination = hive.transform.position;
		yield return new WaitForSeconds (cooldownTime);
	}

	public SwarmKeeper.SwarmStates getState() {
		return state;
	}

	public int getPatchLimit() {
		return patchLimit;
	}

	public void changeState(SwarmKeeper.SwarmStates newState) {
		lastState = state;
		state = newState;
	}

	public bool addPathLocation(GameObject location) {
		if (patchLocations.Count < patchLimit) {
			patchLocations.Add (location);
			return true;
		}

		addLightPath ();

		patchLocations.Add (hive);
		return false;
	}

	void addLightPath() {
		foreach(GameObject obj in patchLocations) {

		}
	}

	public void clearPathLocations() {
		//patchLocations.Clear ();
		foreach (GameObject obj in patchLocations) {
			removePollenCollection (obj);
		}

		patchLocations = new List<GameObject> ();
	}

	void removePollenCollection(GameObject obj) {

		switch(obj.name) {
		case "Dandelions(Clone)":
			obj.GetComponent<Dandelion> ().collectingPollen = false;
			break;
		case "SunFlowers(Clone)":
			obj.GetComponent<Sunflowers> ().collectingPollen = false;
			break;
		case "OrangeTree(Clone)":
			obj.GetComponent<OrangeTree> ().collectingPollen = false;
			break;
		case "Apple Tree(Clone)":
			obj.GetComponent<AppleTree> ().collectingPollen = false;
			break;
		default:
			break;
		}

	}

	public List<GameObject> getPathLocations() {
		return patchLocations;
		state = SwarmKeeper.SwarmStates.IDLE;
	}

	public void move() {
		if (patchLocations.Count != 0 &&
			(state != SwarmKeeper.SwarmStates.IDLE &&
			state != SwarmKeeper.SwarmStates.COOLDOWN)) {

			Vector3 pos = patchLocations[i].transform.position;
			agent.destination = pos;

			float dist = Vector3.Distance (transform.position, pos);

			if (dist < 3) {
				agent.destination = pos;

				if (i == patchLocations.Count-1) {
					i = 0;
					//state = SwarmKeeper.SwarmStates.COOLDOWN;
					//agent.destination = hive.transform.position;
					//StartCoroutine (coolDown());
					//print(this);
					swarmkeeper.minorKillSwitch(this);
					Bank.addNectar (sumArrayValues(Collect.patchValues));
				} else {
					i++;
				}
			}

		}
	}

	int sumArrayValues(int[] array) {
		int sum = 0;

		for (int i = 0; i < array.Length; i++) {
			sum += array [i];
		}

		return sum;
	}

}

