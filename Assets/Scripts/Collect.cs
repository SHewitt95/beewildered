using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collect : MonoBehaviour {

	public static int[] patchValues;
	int spotsSelected;
	GameObject player;
	GameObject hive;

	public GameObject swarm;
	/*public GameObject swarm2;
	public GameObject swarm3;
	public GameObject swarm4;*/

	public static Transform[] goals;
	/*public static Transform[] goals2;
	public static Transform[] goals3;
	public static Transform[] goals4;*/

	public GameObject empty;

	public GameObject swarmKeeper;

	public static bool goalsGotten;

	public UIController uicontroller;



	// Use this for initialization
	void Start () {

		goals = new Transform[3];
		patchValues = new int[3];
		spotsSelected = 0;
		goalsGotten = false;
		player = GameObject.FindGameObjectWithTag ("Player");

		//collectGoals ();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (GameManager.instance.GetCurrentState() == GameManager.GameStates.COLLECT) {

			Debug.Log ("Collect!");
			Swarm swarm = swarmKeeper.gameObject.GetComponent<SwarmKeeper>().getSelectedSwarm();
			uicontroller.showCollectCount (swarm.getPatchLimit()-spotsSelected);

			if (swarm.gameObject.GetComponent<Swarm> ().getState() == SwarmKeeper.SwarmStates.COLLECT) {
				swarm.gameObject.GetComponent<Swarm> ().clearPathLocations ();
			}

			if (Input.GetKeyDown(KeyCode.Return) &&
				GameManager.grid[SnapMovement.staticCurrentPos] == 2 &&
				spotsSelected < swarm.gameObject.GetComponent<Swarm>().getPatchLimit() && 
				!collectingPollen(GameManager.allGameObjects[SnapMovement.staticCurrentPos])) {
				//Transform temp = player.transform;

				patchValues[spotsSelected] = GameManager.gridValues[SnapMovement.staticCurrentPos];

				GameObject temp = (GameObject) Instantiate(empty, player.transform.position, player.transform.rotation);
		
				//goals [spotsSelected] = temp.transform;
				//swarm.addPathLocation (temp);
				swarm.addPathLocation (GameManager.allGameObjects[SnapMovement.staticCurrentPos]);

				//print(GameManager.allGameObjects[SnapMovement.staticCurrentPos].name);

				setPollenCollection (GameManager.allGameObjects[SnapMovement.staticCurrentPos]);


				spotsSelected++;
			}

			if (spotsSelected == swarm.gameObject.GetComponent<Swarm>().getPatchLimit() ||
				GameManager.numOfPlants <= spotsSelected) {
				//GameObject newSwarm;
				//hive = GameObject.FindGameObjectWithTag ("Hive");
				//newSwarm = (GameObject) Instantiate (swarm, hive.transform.position, hive.transform.rotation);
				//print ("Got goals!");
				goalsGotten = true;
				//printGoals ();
				spotsSelected = 0;

				swarm.gameObject.GetComponent<Swarm> ().changeState (SwarmKeeper.SwarmStates.COLLECT);
				uicontroller.hidePressEnterToCollect ();
				uicontroller.hideCollectCount ();
				GameManager.instance.resetState ();
				//printGridValues ();
			}

		}




	
	}

	bool collectingPollen(GameObject obj) {
		switch(obj.name) {
		case "Dandelions(Clone)":
			return obj.GetComponent<Dandelion> ().collectingPollen;
			break;
		case "SunFlowers(Clone)":
			return obj.GetComponent<Sunflowers> ().collectingPollen;
			break;
		case "OrangeTree(Clone)":
			return obj.GetComponent<OrangeTree> ().collectingPollen;
			break;
		case "Apple Tree(Clone)":
			return obj.GetComponent<AppleTree> ().collectingPollen;
			break;
		default:
			return false;
			break;
		}
	}

	void setPollenCollection(GameObject obj) {
		//print (obj);
		switch(obj.name) {
		case "Dandelions(Clone)":
			obj.GetComponent<Dandelion> ().collectingPollen = true;
			break;
		case "SunFlowers(Clone)":
			obj.GetComponent<Sunflowers> ().collectingPollen = true;
			break;
		case "OrangeTree(Clone)":
			obj.GetComponent<OrangeTree> ().collectingPollen = true;
			break;
		case "Apple Tree(Clone)":
			obj.GetComponent<AppleTree> ().collectingPollen = true;
			break;
		default:
			break;
		}
	}

	void printGoals() {
		for (int i = 0; i < goals.Length; i++) {
			print ("Goal " + i + ": X-" + goals[i].position.x + " Z-" + goals[i].position.z);
		}
	}

	public static void InitiateCollectState() {
		//print("Goals length: " + Move.getGoals ().Length);
		//Move.startJourney();
	}


	public static Transform[] collectGoals() {
		/*
		spotsSelected = 0;

		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (Input.GetKeyDown(KeyCode.Return)) {
			goals [spotsSelected] = player.transform;
			spotsSelected++;
		}
			
		print ("Got goals!");
		*/
		return goals;


	}

	public static Transform[] returnGoals() {

		Transform[] myGoals = new Transform[3];

		System.Array.Copy(goals, myGoals, 3);

		goals = new Transform[3];

		return myGoals;
	}

	void printGridValues() {
		for (int i = 0; i < GameManager.gridValues.Length; i++) {

			print ("Index " + i + ": " + GameManager.gridValues[i]);

		}
	}


}
